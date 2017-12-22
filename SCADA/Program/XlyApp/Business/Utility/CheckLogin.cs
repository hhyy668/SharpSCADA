using Newtonsoft.Json;
using System.Web;
using System;
using System.Reflection;
using Easy4net.Entity.ExModel;
using System.Web.Security;
using Easy4net.Utility;

namespace Business
{
    public class CheckLogin
    {
        public readonly static CheckLogin Instance = new CheckLogin();
        UserBLL iuserbll = Engine.GetProvider<UserBLL>();
        /// <summary>
        /// 模拟验证用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool Login(string UserName, string PassWord)
        {
            if (iuserbll.Login(UserName, PassWord)>0)
                return true;
            return false;
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserInfo()
        {
            try
            {
                if (HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
                {
                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie
                    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                    return JsonConvert.DeserializeObject<UserInfo>(Ticket.UserData);//反序列化
                }
                if (HttpContext.Current.Session["userinfo"] != null)
                {
                    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(HttpContext.Current.Session["userinfo"].ToString());//解密
                    return JsonConvert.DeserializeObject<UserInfo>(Ticket.UserData);//反序列化
                }
            }
            catch (Exception e)
            {
                LogHelper.ErrorFormat(MethodBase.GetCurrentMethod().DeclaringType, "获取用户信息报错：{0}", e.Message);
                throw;
            }
            
            return null;
        }
        /// <summary>
        /// 判断登录的用户是否具有某个权限
        /// Code权限编码
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorization(int Code)
        {
            if (HttpContext.Current.Request.IsAuthenticated)//是否通过身份验证
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie
                FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                UserInfo user=JsonConvert.DeserializeObject<UserInfo>(Ticket.UserData);//反序列化
                return user.PermissionList.Split(',').Contains(Code.ToString(), StringComparison.Ordinal);
            }
            return false;
        }
    }
}