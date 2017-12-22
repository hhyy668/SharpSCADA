using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    //私信类型
    public enum LetterTypeEnum
    {
        [Description("备用", true)]
        None = 0,
    }

    public enum NoticeStatusEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("未读")]
        UnRead = 1,
        [Description("已读")]
        Readed = 2
    }
    public enum NoticeTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("系统")]
        Notice = 1,
        [Description("销售")]
        Sale = 2,
        [Description("采购")]
        Purchase = 3,
        [Description("生产")]
        Made = 4,
        [Description("车辆")]
        Vehicle = 5,
        [Description("设备")]
        Device = 6

    }
}
