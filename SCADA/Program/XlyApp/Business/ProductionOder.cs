


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//生产单
	
	public partial class ProductionOderBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public ProductionOderBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    ProductionOder model = dbhelper.FindOne<ProductionOder>("select top 1 * from ProductionOder order by ProductionOderID DESC");
        ///    return model.ProductionOderID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductionOderID)
		{
			ProductionOder model = dbhelper.Get<ProductionOder>(ProductionOderID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(ProductionOder model)
		{
			return dbhelper.Save<ProductionOder>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ProductionOder model)
		{
			return dbhelper.Update<ProductionOder>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProductionOderID)
		{
			 return dbhelper.Remove<ProductionOder>(ProductionOderID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<ProductionOder>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<ProductionOder>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductionOder GetModel(int ProductionOderID)
		{
			  return dbhelper.Get<ProductionOder>(ProductionOderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ProductionOder GetModelByCache(int ProductionOderID)
		{
			
			string CacheKey = "ProductionOderModel-" + ProductionOderID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<ProductionOder>(ProductionOderID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ProductionOder)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ProductionOder> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<ProductionOder>(string.Format("select * from ProductionOder where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from ProductionOder where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<ProductionOder> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "ProductionOderID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<ProductionOder> pr = dbhelper.FindPage<ProductionOder>(string.Format("select * from ProductionOder where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}