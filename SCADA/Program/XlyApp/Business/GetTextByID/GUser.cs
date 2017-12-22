using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using Easy4net.Entity;

namespace Business.GetTextByID
{
    public class GUser
    {
        public readonly static GUser Instance = new GUser();
        UserBLL iuserbll = Engine.GetProvider<UserBLL>();
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public string GetUserName(int ID)
        {
            EUser user = iuserbll.GetModel(ID);
            if (user!=null)//是否存在该用户
            {
                return user.UserName;
            }
            return null;
        }
        /// <summary>
        /// 根据一组用户id获取用户名信息
        /// </summary>
        /// <returns></returns>
        public string GetUserNames(string IDs)
        {
            List<string> users = new List<string>();
            foreach (string userid in IDs.Split(','))//.SpiltStrToIntList())
            {
                EUser user = iuserbll.GetModel(userid.ToInt());
                if (user != null)//是否存在该用户
                {
                    users.Add(user.UserName);
                }
            }
            return string.Join(",", users.ToArray());
        }
    }
}