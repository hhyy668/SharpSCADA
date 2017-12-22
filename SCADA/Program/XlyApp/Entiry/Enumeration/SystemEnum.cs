using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    /// <summary>
    /// 序列号类型
    /// </summary>
    public enum SequenceType
    {
        [Description("未设置", true)]
        None = 0,
        [Description("工程")]
        GC = 1

    }
    /// <summary>
    /// 前置单据类型
    /// </summary>
    public enum ReferTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
    }

    public enum TypeClassEnum
    {
        [Description("未设置", true)]
        None = 0,
    }
    /// <summary>
    /// 导航系统
    /// </summary>
    public enum SlnSysEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("GPS")]
        GPS = 1,
        [Description("BEIDOU")]
        BEIDOU = 2,
        [Description("GLONASS")]
        GLONASS = 3,
        [Description("GALILEO")]
        GALILEO = 4,
        [Description("GPS+BEIDOU")]
        GPS_BEIDOU = 5,
        [Description("ALL")]
        ALL = 6,
    }
}
