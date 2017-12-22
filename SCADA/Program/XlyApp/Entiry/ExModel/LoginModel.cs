using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity.ExModel
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginModel(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }
    }
}
