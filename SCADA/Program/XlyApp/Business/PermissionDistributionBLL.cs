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
	/// PermissionDistribution
	/// </summary>
	public partial class PermissionDistributionBLL
	{
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
        public PermissionDistributionBLL()
		{}
		#region  BasicMethod
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            EPermissionDistribution model = dbhelper.FindOne<EPermissionDistribution>("select top 1 * from XC_PermissionDistribution order by ID DESC");
            return model.ID + 1;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            EPermissionDistribution model = dbhelper.Get<EPermissionDistribution>(ID);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EPermissionDistribution model)
        {
            return dbhelper.Save<EPermissionDistribution>(model) > 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EPermissionDistribution model)
        {
            return dbhelper.Update<EPermissionDistribution>(model) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dbhelper.Remove<EPermissionDistribution>(ID) > 0;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<EPermissionDistribution>(ids) > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EPermissionDistribution GetModel(int ID)
        {
            return dbhelper.Get<EPermissionDistribution>(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EPermissionDistribution GetModelByCache(int ID)
        {

            string CacheKey = "XC_PermissionDistributionModel-" + ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dbhelper.Get<EPermissionDistribution>(ID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (EPermissionDistribution)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EPermissionDistribution> GetModelList(string strWhere)
        {
            return dbhelper.FindBySql<EPermissionDistribution>(string.Format("select * from XC_PermissionDistribution where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dbhelper.Count(string.Format("select count(*) from XC_PermissionDistribution where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public PageResult<EPermissionDistribution> GetListByPage(string strWhere, string orderby, int page, int pagesize)
        {
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields("ID", true);
            PageResult<EPermissionDistribution> pr = dbhelper.FindPage<EPermissionDistribution>(string.Format("select * from XC_PermissionDistribution where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
        }
        #endregion
		#region  ExtensionMethod

        public bool Delete(int objectId, int permissionId)
        {
            return dbhelper.ExcuteSQL(string.Format("delete XC_PermissionDistribution where RoleID={0} and PermissionID={1}",objectId, permissionId))>0;
        }

        public void Add(int objectId, string strNewIds, string strOldIds, DistributionTypeEnum type)
        {
            string[] oldIds = strOldIds.Split(',');//.SpiltStrToIntList();
            string[] newIds = strNewIds.Split(',');
            if (!string.IsNullOrEmpty(strOldIds.Trim()))
            {
                foreach (string oldId in oldIds)
                {
                    if (!newIds.Contains(oldId,StringComparison.Ordinal))
                    {
                        Delete(objectId, oldId.ToInt());
                    }
                }
            }

            foreach (string newId in newIds)
            {
                if (!oldIds.Contains(newId, StringComparison.Ordinal))
                {
                    EPermissionDistribution distribution = new EPermissionDistribution();
                    distribution.RoleID = objectId;
                    distribution.PermissionID = newId.ToInt();
                    distribution.Description = "";
                    Add(distribution);
                }

            }


        }

        public string GetPermissionIDs(int objectId)
        {
            List<EPermissionDistribution> PermissionIDs = GetModelList(string.Format("RoleID={0}", objectId));
            List<int> IDs = PermissionIDs.Select(t=>t.PermissionID).ToList();
            return string.Join(",", IDs).Trim();
        }
        /// <summary>
        /// 根据角色id删除权限分配记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteByRole(int RoleID)
        {
            return dbhelper.ExcuteSQL(string.Format("delete XC_PermissionDistribution where RoleID={0}", RoleID)) > 0;
        }
        /// <summary>
        /// 根据权限id删除权限分配记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteByPermission(int PermissionID)
        {
            return dbhelper.ExcuteSQL(string.Format("delete XC_PermissionDistribution where PermissionID={0}", PermissionID)) > 0;
        }
		#endregion  ExtensionMethod
	}
}

