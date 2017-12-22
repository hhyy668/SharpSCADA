using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    public enum MobileEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("可用")]
        Enabled = 1,
        [Description("不可用")]
        UnAbled = 2,
    }
}
