using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    /// <summary>
    /// 广播星历类型
    /// </summary>
    public enum BroadcastEnum
    {
        [Description("广播星历", true)]
        broadcast = 0,
        [Description("精密星历")]
        precision = 1,
        [Description("其他")]
        others = 2
    }

}
