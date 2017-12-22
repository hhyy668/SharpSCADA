using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Entity
{
    public enum FileTypeEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("用户头像")]
        UserHeadImg = 1,
        [Description("监测站")]
        DetectStation = 2,
        [Description("监测网")]
        DetectNet = 3,

    }
    /// <summary>
    /// 上传文件分类
    /// </summary>
    public enum FileClassEnum
    {
        [Description("未设置", true)]
        None = 0,
        [Description("大文件")]
        BigFile = 1,
        [Description("小文件")]
        SmallFile = 2,
        [Description("仅原图片")]
        Image = 3,
        [Description("上传原图及压缩图")]
        ImageWithCompress = 4,
    }
}
