using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    /// <summary>
    /// 任务单执行状态
    /// </summary>
    public enum JobOrderStatusEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("未开始")]
        UnDone = 1,
        [Description("执行中")]
        Executing = 2,
        [Description("已完成")]
        Completed = 3
    }


}
