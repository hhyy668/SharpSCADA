


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//工艺步骤
	
	public partial class ProcessStepsBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public ProcessStepsBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    ProcessSteps model = dbhelper.FindOne<ProcessSteps>("select top 1 * from ProcessSteps order by ProcessStepsID DESC");
        ///    return model.ProcessStepsID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProcessStepsID)
		{
			ProcessSteps model = dbhelper.Get<ProcessSteps>(ProcessStepsID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(ProcessSteps model)
		{
			return dbhelper.Save<ProcessSteps>(model)>0;		
		}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(List<ProcessSteps> modellist)
        {
            return dbhelper.Save<ProcessSteps>(modellist) > 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProcessSteps model)
		{
			return dbhelper.Update<ProcessSteps>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProcessStepsID)
		{
			 return dbhelper.Remove<ProcessSteps>(ProcessStepsID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<ProcessSteps>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<ProcessSteps>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProcessSteps GetModel(int ProcessStepsID)
		{
			  return dbhelper.Get<ProcessSteps>(ProcessStepsID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ProcessSteps GetModelByCache(int ProcessStepsID)
		{
			
			string CacheKey = "ProcessStepsModel-" + ProcessStepsID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<ProcessSteps>(ProcessStepsID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ProcessSteps)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ProcessSteps> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<ProcessSteps>(string.Format("select * from ProcessSteps where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from ProcessSteps where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<ProcessSteps> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "ProcessStepsID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<ProcessSteps> pr = dbhelper.FindPage<ProcessSteps>(string.Format("select * from ProcessSteps where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}