


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//操作日志

    public partial class OptionLogsBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public OptionLogsBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(OptionLogs model)
		{
			return dbhelper.Save<OptionLogs>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(OptionLogs model)
		{
			return dbhelper.Update<OptionLogs>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long OptionID)
		{
			 return dbhelper.Remove<OptionLogs>(OptionID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<OptionLogs>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<OptionLogs>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public OptionLogs GetModel(long OptionID)
		{
			  return dbhelper.Get<OptionLogs>(OptionID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public OptionLogs GetModelByCache(long OptionID)
		{
			
			string CacheKey = "OptionLogsModel-" + OptionID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<OptionLogs>(OptionID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (OptionLogs)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<OptionLogs> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<OptionLogs>(string.Format("select * from OptionLogs where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from OptionLogs where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<OptionLogs> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "OptionID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<OptionLogs> pr = dbhelper.FindPage<OptionLogs>(string.Format("select * from OptionLogs where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}