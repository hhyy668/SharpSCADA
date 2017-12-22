using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Utility
{
    /// <summary>
    /// 决定函数返回的是什么类型的数据
    /// </summary>
    public enum DataReturnType
    {
        ViewData = 1,//设置并且同时返回ViewData数据
        Json = 2,
    }
}
