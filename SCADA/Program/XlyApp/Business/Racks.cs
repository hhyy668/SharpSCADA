


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//挂具
	
	public partial class RacksBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public RacksBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    Racks model = dbhelper.FindOne<Racks>("select top 1 * from Racks order by RacksID DESC");
        ///    return model.RacksID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RacksID)
		{
			Racks model = dbhelper.Get<Racks>(RacksID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Racks model)
		{
			return dbhelper.Save<Racks>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Racks model)
		{
			return dbhelper.Update<Racks>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RacksID)
		{
			 return dbhelper.Remove<Racks>(RacksID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<Racks>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<Racks>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Racks GetModel(int RacksID)
		{
			  return dbhelper.Get<Racks>(RacksID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Racks GetModelByCache(int RacksID)
		{
			
			string CacheKey = "RacksModel-" + RacksID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<Racks>(RacksID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Racks)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Racks> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<Racks>(string.Format("select * from Racks where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from Racks where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<Racks> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "RacksID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<Racks> pr = dbhelper.FindPage<Racks>(string.Format("select * from Racks where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}