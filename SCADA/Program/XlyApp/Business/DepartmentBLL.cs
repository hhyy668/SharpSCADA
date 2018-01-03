using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
using Easy4net.Context;
using System.Linq;
namespace Business
{
    //XC_Department
    public partial class DepartmentBLL
    {
        Session session = SessionFactory.GetSession();
        //Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
        public DepartmentBLL()
        { }

        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            EDepartment model = session.Find<EDepartment>("select top 1 * from XC_Department order by DepartmentID DESC").FirstOrDefault();
            return model.DepartmentID + 1;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DepartmentID)
        {
            EDepartment model = session.Get<EDepartment>(DepartmentID);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EDepartment model)
        {
            return session.Insert<EDepartment>(model) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EDepartment model)
        {
            return session.Update<EDepartment>(model) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DepartmentID)
        {
            return session.Delete<EDepartment>(DepartmentID) > 0;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return session.Delete<EDepartment>(ids) > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EDepartment GetModel(int DepartmentID)
        {
            return session.Get<EDepartment>(DepartmentID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EDepartment GetModelByCache(int DepartmentID)
        {

            string CacheKey = "XC_DepartmentModel-" + DepartmentID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = session.Get<EDepartment>(DepartmentID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (EDepartment)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EDepartment> GetModelList(string strWhere)
        {
            return session.Find<EDepartment>(string.Format("select * from XC_Department where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return session.Count(string.Format("select * from XC_Department where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public PageResult<EDepartment> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "DepartmentID")
        {
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<EDepartment> pr = session.FindPage<EDepartment>(string.Format("select * from XC_Department where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
        }
        #endregion

    }
}