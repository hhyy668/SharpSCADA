using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Entity;
using Easy4net.Common;
using System.Linq;
using Easy4net.Utility;


namespace Business
{
	/// <summary>
	/// User_Role
	/// </summary>
    public partial class User_RoleBLL
	{
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public User_RoleBLL()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            EUser_Role model = dbhelper.FindOne<EUser_Role>("select top 1 * from XC_User_Role order by ID DESC");
            return model.ID + 1;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            EUser_Role model = dbhelper.Get<EUser_Role>(ID);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EUser_Role model)
        {
            return dbhelper.Save<EUser_Role>(model) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EUser_Role model)
        {
            return dbhelper.Update<EUser_Role>(model) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dbhelper.Remove<EUser_Role>(ID) > 0;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<EUser_Role>(ids) > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EUser_Role GetModel(int ID)
        {
            return dbhelper.Get<EUser_Role>(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EUser_Role GetModelByCache(int ID)
        {

            string CacheKey = "XC_User_RoleModel-" + ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dbhelper.Get<EUser_Role>(ID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (EUser_Role)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EUser_Role> GetModelList(string strWhere)
        {
            return dbhelper.FindBySql<EUser_Role>(string.Format("select * from XC_User_Role where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dbhelper.Count(string.Format("select count(*) from XC_User_Role where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public PageResult<EUser_Role> GetListByPage(string strWhere, string orderby, int page, int pagesize)
        {
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields("ID", true);
            PageResult<EUser_Role> pr = dbhelper.FindPage<EUser_Role>(string.Format("select * from XC_User_Role where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod
        

        public string GetRoleIDs(int userId)
        {
            List<EUser_Role> modellist = dbhelper.FindBySql<EUser_Role>(string.Format("select * from XC_User_Role where Status=1 and UserID={0}",userId));
            List<int> IDs = modellist.Select(t=>t.RoleID).ToList();
            return string.Join(",", IDs).Trim();
            
        }

        public bool Delete(int userId, int roleId)
        {
            return dbhelper.ExcuteSQL(string.Format("delete XC_User_Role where UserID={0} and RoleID={1}", userId, roleId)) > 0;
        }

        public void Add(int userId, string strNewIds, string strOldIds)
        {
            string[] oldIds = strOldIds.Split(',');//.SpiltStrToIntList();
            string[] newIds = strNewIds.Split(',');
            if (!string.IsNullOrEmpty(strOldIds.Trim()))
            {
                foreach (string oldId in oldIds)
                {
                    if (!newIds.Contains(oldId, StringComparison.Ordinal))
                    {
                        Delete(userId,oldId.ToInt());
                    }
                }
            }

            foreach (string newId in newIds)
            {
                if (!oldIds.Contains(newId, StringComparison.Ordinal))
                {
                    EUser_Role userrole = new EUser_Role();
                    userrole.UserID = userId;
                    userrole.RoleID = newId.ToInt();
                    userrole.Description = "";
                    Add(userrole);
                }

            }
        }
        public bool DeleteByUser(int userId)
        {
            return dbhelper.ExcuteSQL(string.Format("delete XC_User_Role where UserID={0}", userId)) > 0;
        }

		#endregion  ExtensionMethod
	}
}

