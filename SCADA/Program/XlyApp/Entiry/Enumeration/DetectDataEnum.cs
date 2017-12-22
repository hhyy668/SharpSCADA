using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    /// <summary>
    /// 值类型
    /// </summary>
    public enum ValueTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("历元解")]
        Liyuan = 1,
        [Description("小时解")]
        Hour = 2,
        [Description("天解")]
        Tian = 3
    }

}
