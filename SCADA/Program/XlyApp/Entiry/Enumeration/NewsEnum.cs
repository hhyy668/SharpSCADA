using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    public enum NewsLeveEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("一级")]
        One = 1,
        [Description("二级")]
        Two = 2,
        [Description("三级")]
        Three = 3
    }

    public enum NewsStatusEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("置顶")]
        Top = 1,
        [Description("关注")]
        Attention = 2,
        [Description("一般")]
        General = 3
    }

    public enum NewsTypeEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("新闻")]
        General = 1,
        [Description("公告")]
        Bulletin = 2,
        [Description("下载")]
        GameDown = 3
    }
}
