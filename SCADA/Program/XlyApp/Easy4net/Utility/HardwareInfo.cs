using System;
using System.Management;

namespace Easy4net.Utility
{
    /// <summary>
    /// 硬件信息类
    /// </summary>
    public class HardwareInfo
    {
        public string HardInfo;
        public HardwareInfo()
        {
            HardInfo = CPUID + ":10:19:" + NetMac+"it"+HardDiskID;
        }
        #region 硬件属性
        /// <summary>
        /// 机器名
        /// </summary>
        public string HostName
        {
            get { return System.Net.Dns.GetHostName(); }
        }

        /// <summary>
        /// CPU编号
        /// </summary>
        public string CPUID
        {
            get { return GetCpuID(); }
        }

        /// <summary>
        /// 硬盘编号
        /// </summary>
        public string HardDiskID
        {
            get { return GetHardDiskID(); }
        }

        /// <summary>
        /// 网卡MAC
        /// </summary>
        public string NetMac
        {
            get { return GetMac(); }
        }

        #endregion

        #region 获取硬件信息的方法
        /// <summary>
        /// 获得CPU编号
        /// </summary>
        /// <returns></returns>
        private string GetCpuID()
        {
            string result = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    result = mo.Properties["ProcessorId"].Value.ToString();
                }
            }
            catch
            {
                return "获取CPUID失败";
            }
            return result;
        }

        /// <summary>
        /// 获得硬盘编号
        /// </summary>
        /// <returns></returns>
        private string GetHardDiskID()
        {
            string result = "";
            try
            {
                ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                ManagementObjectCollection mocHD = mcHD.GetInstances();
                foreach (ManagementObject m in mocHD)
                {
                    if (m["DeviceID"].ToString() == "C:")
                    {
                        result = m["VolumeSerialNumber"].ToString().Trim();
                    }
                }
            }
            catch
            {
                return "获取硬盘ID失败";
            }
            return result;
        }

        /// <summary>
        /// 获得网卡MAC
        /// </summary>
        /// <returns></returns>
        private string GetMac()
        {
            string result = "";
            try
            {
                ManagementClass mcMAC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection mocMAC = mcMAC.GetInstances();
                foreach (ManagementObject m in mocMAC)
                {
                    if ((bool)m["IPEnabled"])
                    {
                        result = m["MacAddress"].ToString();
                    }
                }
            }
            catch
            {
                return "获取MAC失败";
            }
            return result;
        }

        #endregion
    }
}