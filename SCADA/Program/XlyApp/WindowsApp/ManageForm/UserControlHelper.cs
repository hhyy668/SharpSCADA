using LieBaoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsDemo.ManageForm
{
    public class UserControlHelper
    {
        public static string[] GetUserControlPara(string UserControlName)
        {
            var data = DataBaseHelper.GetDB().UserControl.FindByUserControlName(UserControlName);
            if (data != null)
            {
                LieBaoModels.UserControl uc = (LieBaoModels.UserControl)data;               
                string[] str = uc.UserControJson.Split(',');
                string[] parastr = new string[str.Length];
                if (str.Length == uc.JsonLenth)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        parastr[i] = str[i].Split(':')[1].Trim();
                    }
                    return parastr;
                }
            }
            return null;
        }
    }
}
