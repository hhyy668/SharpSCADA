


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//工艺路线
	
	public partial class ProcessRouteBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public ProcessRouteBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    ProcessRoute model = dbhelper.FindOne<ProcessRoute>("select top 1 * from ProcessRoute order by ProcessRouteID DESC");
        ///    return model.ProcessRouteID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProcessRouteID)
		{
			ProcessRoute model = dbhelper.Get<ProcessRoute>(ProcessRouteID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(ProcessRoute model)
		{
			return dbhelper.Save<ProcessRoute>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ProcessRoute model)
		{
			return dbhelper.Update<ProcessRoute>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProcessRouteID)
		{
			 return dbhelper.Remove<ProcessRoute>(ProcessRouteID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<ProcessRoute>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<ProcessRoute>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProcessRoute GetModel(int ProcessRouteID)
		{
			  return dbhelper.Get<ProcessRoute>(ProcessRouteID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ProcessRoute GetModelByCache(int ProcessRouteID)
		{
			
			string CacheKey = "ProcessRouteModel-" + ProcessRouteID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<ProcessRoute>(ProcessRouteID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ProcessRoute)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ProcessRoute> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<ProcessRoute>(string.Format("select * from ProcessRoute where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from ProcessRoute where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<ProcessRoute> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "ProcessRouteID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<ProcessRoute> pr = dbhelper.FindPage<ProcessRoute>(string.Format("select * from ProcessRoute where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}