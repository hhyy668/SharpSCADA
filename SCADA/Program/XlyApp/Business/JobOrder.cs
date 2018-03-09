


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//任务单
	
	public partial class JobOrderBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public JobOrderBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    JobOrder model = dbhelper.FindOne<JobOrder>("select top 1 * from JobOrder order by JobOrderID DESC");
        ///    return model.JobOrderID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JobOrderID)
		{
			JobOrder model = dbhelper.Get<JobOrder>(JobOrderID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(JobOrder model)
		{
			return dbhelper.Save<JobOrder>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JobOrder model)
		{
			return dbhelper.Update<JobOrder>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string JobOrderID)
		{
			 return dbhelper.Remove<JobOrder>(JobOrderID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<JobOrder>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<JobOrder>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JobOrder GetModel(string JobOrderID)
		{
			  return dbhelper.Get<JobOrder>(JobOrderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public JobOrder GetModelByCache(string JobOrderID)
		{
			
			string CacheKey = "JobOrderModel-" + JobOrderID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<JobOrder>(JobOrderID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (JobOrder)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JobOrder> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<JobOrder>(string.Format("select * from JobOrder where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from JobOrder where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<JobOrder> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "JobOrderID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<JobOrder> pr = dbhelper.FindPage<JobOrder>(string.Format("select * from JobOrder where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}