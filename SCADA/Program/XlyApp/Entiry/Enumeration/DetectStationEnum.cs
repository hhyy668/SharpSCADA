using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
     /// <summary>
    /// 监测站类型
    /// </summary>
    public enum DetectStationTypeEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("基准站")]
        Base = 1,
        [Description("移动站")]
        Move = 2,
        [Description("广播星历")]
        Star = 3,
        [Description("差分信息站")]
        Diff = 4
    }
    /// <summary>
    /// 通讯类型0空1TC|2TS|3NC|4NS|5SE >6保留
    /// </summary>
    public enum CommunicationTypeEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("SERIAL")]
        SERIAL = 1,
        [Description("FILE")]
        FILE = 2,
        [Description("TCP SERVER")]
        TCPSERVER = 3,
        [Description("TCP CLIENT")]
        TCPCLIENT = 4,
        [Description("UDP")]
        UDP = 5,
        [Description("NTRIP SERVER")]
        NTRIPSERVER = 6,
        [Description("NTRIP CLIENT")]
        NTRIPCLIENT = 7,
        [Description("FTP")]
        FTP = 8,
        [Description("HTTP")]
        HTTP = 9
    }
    public enum LinkStatusEnum
    {
        /// <summary>
        /// 连接状态
        /// </summary>
        [Description("未设置", true)]
        None = 0,
        [Description("断开")]
        off = 1,
        [Description("异常")]
        innormal = 2,
        [Description("正常")]
        normal = 3
    }
    /// <summary>
    /// 异常告警标识
    /// </summary>
    public enum InormalWarningEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("无异常")]
        Normal = 1,
        [Description("仪器异常")]
        DeviceInnormal = 2,
        [Description("温度异常")]
        TemInnormal = 3
    }

    /// <summary>
    /// 供电模式
    /// </summary>
    public enum PowModelEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("铅蓄电池")]
        QianBattery = 1,
        [Description("锂电池")]
        LiBattery = 2,
        [Description("交流电")]
        JiaoBattery = 3
    }
    /// <summary>
    /// 电源电量
    /// </summary>
    public enum PowQuantityEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("无电")]
        Nopow = 1,
        [Description("满电")]
        Fullpow = 2
    }
    /// <summary>
    /// 内部存储
    /// </summary>
    public enum InStoreEnum
    {
        [Description("未设置")]
        None = 0,
        [Description("无可用空间")]
        NoUsage = 1,
        [Description("全部可用")]
        AllUsage = 2
    }

}
