﻿using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Reflection;
using Newtonsoft.Json;
using System.Web.SessionState;
using Easy4net.Utility;

namespace Business
{
    public class MyPrincipal<TUserData> : IPrincipal,IReadOnlySessionState
     where TUserData : class, new()
    {
        private IIdentity _identity;
        private TUserData _userData;
        
        public MyPrincipal(FormsAuthenticationTicket ticket, TUserData userData)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            if (userData == null)
                throw new ArgumentNullException("userData");

            _identity = new FormsIdentity(ticket);
            _userData = userData;
        }

        public TUserData UserData
        {
            get { return _userData; }
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }
        
        public bool IsInRole(string role)
        {
            // 把判断用户组的操作留给UserData去实现。

            IPrincipal principal = _userData as IPrincipal;
            if (principal == null)
                throw new NotImplementedException();
            else
                return principal.IsInRole(role);
        }

        /// <summary>
        /// 执行用户登录操作
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="userData">与登录名相关的用户信息</param>
        /// <param name="expiration">登录Cookie的过期时间，单位：分钟。</param>
        public static void SignIn(string loginName, TUserData userData, int expiration)
        {
            if (string.IsNullOrEmpty(loginName))
                throw new ArgumentNullException("loginName");
            if (userData == null)
                throw new ArgumentNullException("userData");

            // 1. 把需要保存的用户数据转成一个字符串。
            string data = null;
            if (userData != null)
                data = JsonConvert.SerializeObject(userData);


            // 2. 创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2, loginName, DateTime.Now, DateTime.Now.AddDays(1), true, data);


            // 3. 加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);


            // 4. 根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (expiration > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expiration);

            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();

            // 5. 写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
            // 6.写入session
            context.Session.Remove("userinfo");
            context.Session.Add("userinfo", cookieValue);
        }

        /// <summary>
        /// 根据HttpContext对象设置用户标识对象
        /// </summary>
        /// <param name="context"></param>
        public static void TrySetUserInfo(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            // 1. 读登录Cookie
            HttpCookie cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return;

            try
            {
                TUserData userData = null;
                // 2. 解密Cookie值，获取FormsAuthenticationTicket对象
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket != null && string.IsNullOrEmpty(ticket.UserData) == false)
                    userData = JsonConvert.DeserializeObject<TUserData>(ticket.UserData); // 3. 还原用户数据

                if (ticket != null && userData != null)
                    context.User = new MyPrincipal<TUserData>(ticket, userData); // 4. 构造我们的MyFormsPrincipal实例，重新给context.User赋值。
                HttpContext.Current.User = new MyPrincipal<TUserData>(ticket, userData); 
            }
            catch (Exception e)
            {
                /* 异常只记录到日志并不抛出，防止攻击者试探。 */
                LogHelper.Info(MethodBase.GetCurrentMethod().DeclaringType, e);
            }
        }
    }

}