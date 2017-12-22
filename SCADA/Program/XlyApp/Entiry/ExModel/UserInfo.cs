using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Easy4net.Entity.ExModel
{
    [Serializable]
    public class UserInfo
    {

        /// <summary>
        /// AccessToken
        /// </summary>
        [DisplayName("AccessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        [DisplayName("UserID")]
        public int UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        [DisplayName("权限")]
        public string PermissionList { get; set; }
    }
}
