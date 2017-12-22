using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity.ExModel
{
  public   class SMSModel
    {
      /// <summary>
      /// 手机号列表
      /// </summary>
     public string mobiles{get;set;}
      /// <summary>
      /// 短信内容
      /// </summary>
      public  string content{get;set;}
      /// <summary>
      /// 扩展码
      /// </summary>
      public string ext{get;set;}
      /// <summary>
      /// 定时时间
      /// </summary>
      public string stime{get;set;}
      /// <summary>
      /// 流水号
      /// </summary>
      public string rrid { get; set; }
      /// <summary>
      /// 序列号
      /// </summary>
      public string sn { get; set; }
      /// <summary>
      /// 密码
      /// </summary>
      public string pwd { get; set; }


    }
}
