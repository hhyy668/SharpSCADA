


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//行车
	
	public partial class BridgeCraneBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public BridgeCraneBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    BridgeCrane model = dbhelper.FindOne<BridgeCrane>("select top 1 * from BridgeCrane order by BridgeCraneID DESC");
        ///    return model.BridgeCraneID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BridgeCraneID)
		{
			BridgeCrane model = dbhelper.Get<BridgeCrane>(BridgeCraneID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(BridgeCrane model)
		{
			return dbhelper.Save<BridgeCrane>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BridgeCrane model)
		{
			return dbhelper.Update<BridgeCrane>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BridgeCraneID)
		{
			 return dbhelper.Remove<BridgeCrane>(BridgeCraneID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<BridgeCrane>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<BridgeCrane>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BridgeCrane GetModel(int BridgeCraneID)
		{
			  return dbhelper.Get<BridgeCrane>(BridgeCraneID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BridgeCrane GetModelByCache(int BridgeCraneID)
		{
			
			string CacheKey = "BridgeCraneModel-" + BridgeCraneID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<BridgeCrane>(BridgeCraneID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BridgeCrane)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BridgeCrane> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<BridgeCrane>(string.Format("select * from BridgeCrane where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from BridgeCrane where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<BridgeCrane> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "BridgeCraneID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<BridgeCrane> pr = dbhelper.FindPage<BridgeCrane>(string.Format("select * from BridgeCrane where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}