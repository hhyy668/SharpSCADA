


using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;
namespace Business
{
	
 	//物料类型表
	
	public partial class MaterielBLL
	{
		 Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public MaterielBLL()
		{}
		
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        ///public int GetMaxId()
        ///{
        ///    Materiel model = dbhelper.FindOne<Materiel>("select top 1 * from Materiel order by MaterielID DESC");
        ///    return model.MaterielID + 1;
        ///}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MaterielID)
		{
			Materiel model = dbhelper.Get<Materiel>(MaterielID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Materiel model)
		{
			return dbhelper.Save<Materiel>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Materiel model)
		{
			return dbhelper.Update<Materiel>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MaterielID)
		{
			 return dbhelper.Remove<Materiel>(MaterielID)>0;
		}
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string list )
		{
			return dbhelper.Remove<Materiel>(list) > 0;
		}
		
		/// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<Materiel>(ids) > 0;
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Materiel GetModel(int MaterielID)
		{
			  return dbhelper.Get<Materiel>(MaterielID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Materiel GetModelByCache(int MaterielID)
		{
			
			string CacheKey = "MaterielModel-" + MaterielID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<Materiel>(MaterielID); 
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Materiel)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Materiel> GetModelList(string strWhere)
		{
			return dbhelper.FindBySql<Materiel>(string.Format("select * from Materiel where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from Materiel where {0}",  strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<Materiel> GetListByPage(string strWhere = "", int page = 1, int pagesize = 30, string orderby = "MaterielID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<Materiel> pr = dbhelper.FindPage<Materiel>(string.Format("select * from Materiel where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
#endregion
   
	}
}