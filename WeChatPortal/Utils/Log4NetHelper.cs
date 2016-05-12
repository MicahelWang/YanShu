using System;

namespace WeChatPortal.Utils
{
    /// <summary>
    /// 使用LOG4NET记录日志的功能，在WEB.CONFIG里要配置相应的节点
    /// </summary>
    public class Log4NetHelper
    {
        //log4net日志专用
        private static readonly log4net.ILog LogInfo = log4net.LogManager.GetLogger("loginfo");
        private static readonly log4net.ILog LogError = log4net.LogManager.GetLogger("logerror");
        private static readonly log4net.ILog LogDebug = log4net.LogManager.GetLogger("logdebug");

        static Log4NetHelper()
        {
            SetConfig();
        }

        private static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        //public static void SetConfig(FileInfo configFile)
        //{
        //    log4net.Config.XmlConfigurator.Configure(configFile);
        //}

        /// <summary>
        /// 普通的文件记录日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if (LogInfo.IsInfoEnabled)
            {
                LogInfo.Info(info);
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public static void WriteError(string info, Exception se)
        {
            if (LogError.IsErrorEnabled)
            {
                LogError.Error(info, se);
            }
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteDebug(string info)
        {
            if (LogDebug.IsDebugEnabled)
            {
                LogDebug.Info(info);
            }
        }
    }
}
