using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Entity;
using Easy4net.Common;
using Easy4net.Utility;


namespace Business
{
    /// <summary>
    /// XC_Report
    /// </summary>
    public partial class ReportBLL
    {
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
        public ReportBLL()
		{}
      /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            EReport model = dbhelper.FindOne<EReport>("select top 1 * from XC_Report order by ID DESC");
            return model.ID + 1;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			EReport model = dbhelper.Get<EReport>(ID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(EReport model)
		{
			return dbhelper.Save<EReport>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EReport model)
		{
			return dbhelper.Update<EReport>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			 return dbhelper.Remove<EReport>(ID)>0;
		}
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<EReport>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EReport GetModel(int ID)
		{
			  return dbhelper.Get<EReport>(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EReport GetModelByCache(int ID)
		{
			
			string CacheKey = "XC_ReportModel-" + ID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<EReport>(ID); 
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EReport)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EReport> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<EReport>(string.Format("select * from XC_Report where {0}", strWhere.IsNullOrEmpty()?"1=1":strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from XC_Report where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<EReport> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "ID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<EReport> pr = dbhelper.FindPage<EReport>(string.Format("select * from XC_Report where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

