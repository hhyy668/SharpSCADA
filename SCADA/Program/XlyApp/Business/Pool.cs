using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//池信息
	
	public partial class PoolBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public PoolBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    Pool model = dbhelper.FindOne<Pool>("select top 1 * from Pool order by PoolID DESC");
        ///    return model.PoolID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PoolID)
		{
			Pool model = dbhelper.Get<Pool>(PoolID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Pool model)
		{
			return dbhelper.Save<Pool>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pool model)
		{
			return dbhelper.Update<Pool>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PoolID)
		{
			 return dbhelper.Remove<Pool>(PoolID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<Pool>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<Pool>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pool GetModel(int PoolID)
		{
			  return dbhelper.Get<Pool>(PoolID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Pool GetModelByCache(int PoolID)
		{
			
			string CacheKey = "PoolModel-" + PoolID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<Pool>(PoolID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pool)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pool> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<Pool>(string.Format("select * from Pool where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from Pool where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<Pool> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "PoolID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<Pool> pr = dbhelper.FindPage<Pool>(string.Format("select * from Pool where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}