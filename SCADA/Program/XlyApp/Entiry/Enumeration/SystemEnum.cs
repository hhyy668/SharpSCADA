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
    /// 池类型
    /// </summary>
    public enum PoolTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("进料池")]
        InPool = 1,
        [Description("水洗池")]
        WaterPool = 2,
        [Description("浓酸池")]
        StrongPicklingPool = 3,
        [Description("普通酸洗")]
        PicklingPool = 4,
        [Description("出料池")]
        OutPool = 5,
    }
    
    public enum EditModeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("新建")]
        Add = 1,
        [Description("修改")]
        Modify = 2,
    }
}
