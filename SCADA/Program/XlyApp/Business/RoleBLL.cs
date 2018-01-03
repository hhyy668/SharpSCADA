using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Entity;
using Easy4net.Common;
using Easy4net.Utility;


namespace Business
{
	/// <summary>
	/// Role
	/// </summary>
	public partial class RoleBLL
	{
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public RoleBLL()
		{}
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            ERole model = dbhelper.FindOne<ERole>("select top 1 * from XC_Role order by RoleID DESC");
            return model.RoleID + 1;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID)
		{
            ERole model = dbhelper.Get<ERole>(RoleID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(ERole model)
		{
            return dbhelper.Save<ERole>(model);		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(ERole model)
		{
            return dbhelper.Update<ERole>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleID)
		{
            return dbhelper.Remove<ERole>(RoleID) > 0;
		}
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<ERole>(ids) > 0;
        }
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public ERole GetModel(int RoleID)
		{
            return dbhelper.Get<ERole>(RoleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public ERole GetModelByCache(int RoleID)
		{
			
			string CacheKey = "XC_RoleModel-" + RoleID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dbhelper.Get<ERole>(RoleID); 
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (ERole)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<ERole> GetModelList(string strWhere)
		{
            return dbhelper.FindBySql<ERole>(string.Format("select * from XC_Role where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from XC_Role where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<ERole> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "RoleID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<ERole> pr = dbhelper.FindPage<ERole>(string.Format("select * from XC_Role where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
		#region  ExtensionMethod
       
		#endregion  ExtensionMethod
	}
}

