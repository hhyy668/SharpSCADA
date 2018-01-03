using System;
using System.Data;
using System.Collections.Generic;
using Easy4net.Common;
using Easy4net.Entity;
using Easy4net.Utility;


namespace Business
{
	/// <summary>
	/// 通知表
	/// </summary>
    public partial class NoticeBLL
	{
        Easy4net.DBUtility.DBHelper dbhelper = Easy4net.DBUtility.DBHelper.getInstance("SqlServerString");
		public NoticeBLL()
		{}
		#region  Method
		 /// <summary>
        /// 得到最大ID
        /// </summary>
        public long GetMaxId()
        {
            ENotice model = dbhelper.FindOne<ENotice>("select top 1 * from XC_Notice order by NoticeID DESC");
            return model.NoticeID + 1;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long NoticeID)
		{
			ENotice model = dbhelper.Get<ENotice>(NoticeID);
			 if (model != null)
            {
                return true;
            }
            return false;
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(ENotice model)
		{
			return dbhelper.Save<ENotice>(model)>0;		
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ENotice model)
		{
			return dbhelper.Update<ENotice>(model) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long NoticeID)
		{
			 return dbhelper.Remove<ENotice>(NoticeID)>0;
		}
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool Delete(object[] ids)
        {
            return dbhelper.Remove<ENotice>(ids) > 0;
        }
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ENotice GetModel(long NoticeID)
		{
			  return dbhelper.Get<ENotice>(NoticeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ENotice GetModelByCache(long NoticeID)
		{
			
			string CacheKey = "XC_NoticeModel-" + NoticeID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
				 	objModel = dbhelper.Get<ENotice>(NoticeID); 
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ENotice)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ENotice> GetModelList(string strWhere)
		{
            return dbhelper.FindBySql<ENotice>(string.Format("select * from XC_Notice where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}	
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
            return dbhelper.Count(string.Format("select count(*) from XC_Notice where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere));
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public PageResult<ENotice> GetListByPage(string strWhere="", int page=1, int pagesize=30, string orderby="NoticeID")
		{
            ParamMap param = ParamMap.newMap();
            param.setPageParamters(page, pagesize);
            param.setOrderFields(orderby, true);
            PageResult<ENotice> pr = dbhelper.FindPage<ENotice>(string.Format("select * from XC_Notice where {0}", strWhere.IsNullOrEmpty() ? "1=1" : strWhere), param);
            pr.page = page;
            pr.pagesize = pagesize;
            return pr;
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public ENotice CreateNotice(string title, string content, int senduserid, int accessuserid, short typeid)
        {
            ENotice notice = new ENotice();
            notice.Title = title;
            notice.PublishTime = DateTime.Now;
            notice.Content = content;
            notice.SendUserID = senduserid;
            notice.AccessUserID = accessuserid;
            notice.TypeID = typeid;
            notice.NoticeStatus = (short)NoticeStatusEnum.UnRead; ;

            long id = dbhelper.Save<ENotice>(notice);
            if (id > 0)
            {
                notice.NoticeID = id;
                return notice;
            }
            else
            {
                return null;
            }
        }
		#endregion  ExtensionMethod
	}
}

