using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum PermissionTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("目录权限")]
        Directory = 1,
        [Description("操作权限")]
        Operation = 2,
    }
    /// <summary>
    /// 权限所属模块
    /// </summary>
    public enum PermissionClassEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("监测管理")]
        Slip = 1,
        [Description("分析报表")]
        Report = 2,
        [Description("系统管理")]
        System = 4,
        [Description("消息通知")]
        Notice = 5
              

    }

    public enum DistributionTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("用户")]
        User = 1,
        [Description("角色")]
        Role = 2,
    }

}
