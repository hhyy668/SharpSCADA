using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Easy4net.Utility
{
    public class LogHelper
    {
           //private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
           public static void Debug(Type T, object message)
           {
               log4net.LogManager.GetLogger(T).Debug(message);
           }

           public static void Debug(Type T, object message, Exception e)
           {
               log4net.LogManager.GetLogger(T).Debug(message, e);
           }

           public static void Info(Type T, object message)
           {
               log4net.LogManager.GetLogger(T).Info(message);
           }

           public static void Info(Type T, object message, Exception e)
           {
               log4net.LogManager.GetLogger(T).Info(message, e);
           }

           public static void Warn(Type T, object message)
           {
               log4net.LogManager.GetLogger(T).Warn(message);
           }

           public static void Warn(Type T, object message, Exception e)
           {
               log4net.LogManager.GetLogger(T).Warn(message, e);
           }

           public static void Error(Type T, object message)
           {
               log4net.LogManager.GetLogger(T).Error(message);
           }

           public static void Error(Type T, object message, Exception e)
           {
               log4net.LogManager.GetLogger(T).Error(message, e);
           }

           public static void Fatal(Type T, object message)
           {
               log4net.LogManager.GetLogger(T).Fatal(message);
           }

           public static void Fatal(Type T, object message, Exception e)
           {
               log4net.LogManager.GetLogger(T).Fatal(message, e);
           }

      
           /// <summary>
           /// 记录DEBUG信息
           /// </summary>
           /// <param name="format"></param>
           /// <param name="args"></param>
           public static void DebugFormat(Type T, string format, params object[] args)
           {
               log4net.LogManager.GetLogger(T).DebugFormat(format, args);
           }
           /// <summary>
           /// 记录INFO信息
           /// </summary>
           /// <param name="format"></param>
           /// <param name="args"></param>
           public static void InfoFormat(Type T, string format, params object[] args)
           {
               log4net.LogManager.GetLogger(T).InfoFormat(format, args);
           }
           public static void WarnFormat(Type T, string warn, params object[] args)
           {
               log4net.LogManager.GetLogger(T).WarnFormat(warn, args);
           }
           /// <summary>
           /// 记录ERRO信息
           /// </summary>
           /// <param name="format"></param>
           /// <param name="args"></param>
           public static void ErrorFormat(Type T, string format, params object[] args)
           {
               log4net.LogManager.GetLogger(T).ErrorFormat(format, args);
           }
           /// <summary>
           /// 记录Fatal信息
           /// </summary>
           /// <param name="format"></param>
           /// <param name="args"></param>
           public static void FatalFormat(Type T, string format, params object[] args)
           {
               log4net.LogManager.GetLogger(T).FatalFormat(format, args);
           }  
    }
}
