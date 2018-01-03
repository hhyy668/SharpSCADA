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
	/// <summary>
	/// Permission
	/// </summary>
	public partial class PermissionBLL
	{
        Session session = SessionFactory.GetSession();
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");

		public PermissionBLL()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            EPermission model = dbhelper.FindOne<EPermission>("select top 1 * from XC_Permission order by PermissionID DESC");
            return model.PermissionID + 1;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PermissionID)
        {
            EPermission model = dbhelper.Get<EPermission>(PermissionID);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EPermission model)
        {
            return dbhelper.Save<EPermission>(model) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EPermission model)
        {
            return dbhelper.Update<EPermission>(model) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PermissionID)
        {
            return dbhelper.Remove<EPermission>(PermissionID) > 0;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<EPermission>(ids) > 0;
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string list)
        {
            return dbhelper.Remove<EPermission>(list) > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EPermission GetModel(int PermissionID)
        {
            return dbhelper.Get<EPermission>(PermissionID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EPermission GetModelByCache(int PermissionID)
        {

            string CacheKey = "XC_PermissionModel-" + PermissionID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dbhelper.Get<EPermission>(PermissionID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (EPermission)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EPermission> GetModelList(string strWhere)
        {
            return dbhelper.FindBySql<EPermission>(string.Format("select * from XC_Permission where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }	

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dbhelper.Count(string.Format("select count(*) from XC_Permission where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public PageResult<EPermission> GetListByPage(string strWhere = "", int page = 1, int pagesize = 10, string orderby = "PermissionID")
        {
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<EPermission> pr = dbhelper.FindPage<EPermission>(string.Format("select * from XC_Permission where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
        }
		

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

