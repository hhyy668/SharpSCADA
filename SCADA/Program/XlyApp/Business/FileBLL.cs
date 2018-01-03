using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Entity;
using Easy4net.Common;
using Easy4net.Utility;

namespace Business
{
	/// <summary>
	/// 文件表
	/// </summary>
    public partial class FileBLL
	{
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public FileBLL()
		{}
		#region  BasicMethod
        public bool Exists(short fileType, string referId)
        {
            EFile efile = dbhelper.FindOne<EFile>(string.Format("select * from XC_File where FileType={0} and ReferID='{1}'", fileType, referId));
            if (efile != null)
            {
                return true;
            }
            return false;
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(EFile efile)
		{
            return dbhelper.Save<EFile>(efile);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(EFile efile)
		{
            return dbhelper.Update<EFile>(efile) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long FileID)
		{
            return dbhelper.Remove<EFile>(FileID)>0;
		}
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<EFile>(ids) > 0;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public EFile GetModel(int fileType, string referId)
        {
            return dbhelper.FindOne<EFile>(string.Format("select * from XC_File where FileType={0} and ReferID='{1}'", fileType, referId));
        }
        public EFile GetModel(long FileID)
		{

            return dbhelper.Get<EFile>(FileID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public EFile GetModelByCache(long FileID)
		{
			
			string CacheKey = "FileModel-" + FileID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dbhelper.Get<EFile>(FileID); 
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (EFile)objModel;
		}

        public List<EFile> GetModelList(string strWhere)
		{
            return dbhelper.FindBySql<EFile>(string.Format("select * from XC_File where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        //public List<EFile> DataTableToList(DataTable dt)
        //{
        //    List<EFile> modelList = new List<EFile>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        EFile model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model =dal.DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}


		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from XC_File where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<EFile> GetListByPage(string strWhere = "", int page = 1, int pagesize = 10, string orderby = "UserID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<EFile> pr = dbhelper.FindPage<EFile>(string.Format("select * from XC_User where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
       
		#endregion  ExtensionMethod
	}
}

