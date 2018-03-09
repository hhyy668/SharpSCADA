using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//ReciveRecord
	
	public partial class ReciveRecordBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public ReciveRecordBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    ReciveRecord model = dbhelper.FindOne<ReciveRecord>("select top 1 * from ReciveRecord order by ReciveRecordID DESC");
        ///    return model.ReciveRecordID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReciveRecordID)
		{
			ReciveRecord model = dbhelper.Get<ReciveRecord>(ReciveRecordID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(ReciveRecord model)
		{
			return dbhelper.Save<ReciveRecord>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ReciveRecord model)
		{
			return dbhelper.Update<ReciveRecord>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ReciveRecordID)
		{
			 return dbhelper.Remove<ReciveRecord>(ReciveRecordID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<ReciveRecord>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<ReciveRecord>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ReciveRecord GetModel(string ReciveRecordID)
		{
			  return dbhelper.Get<ReciveRecord>(ReciveRecordID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ReciveRecord GetModelByCache(string ReciveRecordID)
		{
			
			string CacheKey = "ReciveRecordModel-" + ReciveRecordID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<ReciveRecord>(ReciveRecordID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ReciveRecord)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ReciveRecord> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<ReciveRecord>(string.Format("select * from ReciveRecord where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from ReciveRecord where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<ReciveRecord> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "ReciveRecordID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<ReciveRecord> pr = dbhelper.FindPage<ReciveRecord>(string.Format("select * from ReciveRecord where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}