using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity.ExModel
{
   public class EmailModel
    {
       public EmailModel()
       {


       }
       /// <summary>
        /// 收件人邮件地址
       /// </summary>
      public string Tomail{set;get;}
       /// <summary>
      /// 标题
       /// </summary>
      public   string Title{set;get;}
       /// <summary>
       /// 正文
       /// </summary>
      public string Content{get;set;}
       /// <summary>
       /// 发件人账号
       /// </summary>
      public string FormUser{get;set;}
       /// <summary>
       /// 发件人密码
       /// </summary>
      public string FromUserPwd { get; set; }
       /// <summary>
      /// 发件服务器
       /// </summa>
      public string FromService { get; set; }
       /// <summary>
       /// 发件端口
       /// </summary>
      public int FromPort { get; set; }

    }
}
