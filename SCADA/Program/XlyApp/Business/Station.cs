


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//工位信息
	
	public partial class StationBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public StationBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    Station model = dbhelper.FindOne<Station>("select top 1 * from Station order by StationID DESC");
        ///    return model.StationID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StationID)
		{
			Station model = dbhelper.Get<Station>(StationID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Station model)
		{
			return dbhelper.Save<Station>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Station model)
		{
			return dbhelper.Update<Station>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StationID)
		{
			 return dbhelper.Remove<Station>(StationID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<Station>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<Station>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Station GetModel(int StationID)
		{
			  return dbhelper.Get<Station>(StationID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Station GetModelByCache(int StationID)
		{
			
			string CacheKey = "StationModel-" + StationID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<Station>(StationID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Station)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Station> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<Station>(string.Format("select * from Station where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from Station where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<Station> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "StationID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<Station> pr = dbhelper.FindPage<Station>(string.Format("select * from Station where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}