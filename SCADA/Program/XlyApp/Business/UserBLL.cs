using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Easy4net.Context;
using Easy4net.Entity;
using Easy4net.Entity.ExModel;
using Easy4net.Common;
using Newtonsoft.Json;
using Easy4net.Utility;


namespace Business
{
    /// <summary>
    /// User
    /// </summary>
    public partial class UserBLL
    {
        Session session = SessionFactory.GetSession();
        //Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
        public UserBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            EUser user = session.Find<EUser>("select top 1 * from XC_User order by UserID DESC").FirstOrDefault();
            return user.UserID + 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            EUser euser = session.Get<EUser>(UserID);
            if (euser != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EUser model,out string msg)
        {
            msg = "";
            int count = session.Count(string.Format("select * from XC_User where UserName='{0}'", model.UserName));
            if (count > 0)
            {
                msg = "该用户名已存在！";
                return 0;
            }
            return session.Insert<EUser>(model);
        }

        /// <summary>t
        /// 更新一条数据
        /// </summary>
        public bool Update(EUser model, out string msg)
        {
            msg = "";
            int count = session.Count(string.Format("select * from XC_User where UserName='{0}' and UserID<>'{1}'", model.UserName, model.UserID));
            if (count > 0)
            {
                msg = "该用户名已存在！";
                return false;
            }
            return session.Update<EUser>(model) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            return session.Delete<EUser>(UserID) > 0;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return session.Delete<EUser>(ids) > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EUser GetModel(int UserID)
        {
            return session.Get<EUser>(UserID);
        }
       

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EUser GetModelByCache(int UserID)
        {

            string CacheKey = "UserModel-" + UserID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = session.Get<EUser>(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch {
                }
            }
            return (EUser)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EUser> GetModelList(string strWhere)
        {
            return session.Find<EUser>(string.Format("select * from XC_User where {0}", strWhere));
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return session.Count(string.Format("select count(*) from XC_User where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public PageResult<EUser> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "UserID")
        {
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<EUser> pr = session.FindPage<EUser>(string.Format("select * from XC_User where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public int Login(string UserName, string Password)
        {
            try
            {
                List<EUser> userlist = GetModelList(string.Format("UserName='{0}'", UserName));
                if (userlist.Count == 1)
                {
                    if (userlist.FirstOrDefault().Password == Encrypt.PasswordEncryption(Password, userlist.FirstOrDefault().PasswordSalt))
                        return userlist.FirstOrDefault().UserID;
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "登录失败", ex);
                return 0;
            }

        }
        public bool CheckUser(string value, int PermissionID)
        {
            //参数合法性校验
            value = Encrypt.Decryption(value);
            LoginModel args = JsonConvert.DeserializeObject<LoginModel>(value);
            if (args == null || string.IsNullOrEmpty(args.UserName) || string.IsNullOrEmpty(args.Password))
            {
                //如果两个参数任意一个为空，返回错误信息
                return false;
            }
            int userid = Login(args.UserName, args.Password);
            if (userid > 0)
            {

                if (PermissionID == 0)
                {
                    return true;
                }
                else
                {
                    UserInfo userinfo = GetUserInfoByUserID(userid);
                    return userinfo.PermissionList.Split(',').Contains(PermissionID.ToString(),StringComparison.Ordinal);
                }
            }
            else
            {
                return false;
            }

        }
        public bool CheckUser(string value, int PermissionID, out UserInfo userinfo)
        {
            //参数合法性校验
            value = Encrypt.Decryption(value);
            LoginModel args = JsonConvert.DeserializeObject<LoginModel>(value);
            if (args == null || string.IsNullOrEmpty(args.UserName) || string.IsNullOrEmpty(args.Password))
            {
                //如果两个参数任意一个为空，返回错误信息
                userinfo = null;
                return false;
            }
            int userid = Login(args.UserName, args.Password);
            if (userid > 0)
            {
                userinfo = GetUserInfoByUserID(userid);
                if (PermissionID == 0)
                {
                    return true;
                }
                else
                {
                    return userinfo.PermissionList.Split(',').Contains(PermissionID.ToString(),StringComparison.Ordinal);
                }
            }
            else
            {
                userinfo = null;
                return false;
            }

        }
        /// <summary>
        /// 根据用户id获取用户信息含权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByUserID(int UserID)
        {
            EUser user = session.Get<EUser>(UserID);
            UserInfo userinfo = new UserInfo();
            userinfo.UserID = user.UserID;
            userinfo.UserName = user.UserName;
            List<EUser_Role> userroles = session.Find<EUser_Role>(string.Format("SELECT * FROM XC_User_Role where UserID={0}", userinfo.UserID));
            string ids = "";
            foreach (EUser_Role item in userroles)
            {
                List<int> IDs = session.Find<EPermissionDistribution>("select * from XC_PermissionDistribution where RoleID=" + item.RoleID).Select(a=>a.PermissionID).ToList<int>();
                string tempids = string.Join(",", IDs).Trim();
                if (!string.IsNullOrEmpty(ids) && !string.IsNullOrEmpty(tempids))
                {
                    ids = ids + "," + tempids;
                }
                else
                {
                    ids = ids + tempids;
                }
            }
            IList<int> list = StringExtension.SpiltStrToIntList(ids).Distinct().ToList();
            ids = string.Join(",", list).Trim(); ;
            userinfo.PermissionList = ids;
            return userinfo;

        }

        #endregion  ExtensionMethod
    }
}

