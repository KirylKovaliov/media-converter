using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;

namespace MediaServices.Common
{

    public enum Severity
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal,
    }

    public static class Log
    {
        public static void Initialize()
        {
            LogManager.Configuration = GetLoggingConfiguration();
            Instance = LogManager.GetLogger("CommonLogger");
        }

        private static LoggingConfiguration GetLoggingConfiguration()
        {
            string assemblyLocation = new Uri(typeof(Log).Assembly.CodeBase).LocalPath;
            string folder = Path.GetDirectoryName(assemblyLocation);
            string logConfigLocation = Path.Combine(folder, @"NLog.config");
            return new XmlLoggingConfiguration(logConfigLocation);
        }

        public static Logger Instance { get; private set; }

        public static void Debug(string message, params object[] args)
        {
            if (Instance == null)
            {
                Console.WriteLine(message, args);
            }
            else
            {
                Instance.Debug(string.Format(message, args));
                Console.WriteLine(message, args);
            }

        }

        public static void Info(string message, params object[] args)
        {
            if (Instance == null)
            {
                Console.WriteLine(message, args);
            }
            else
            {
                Instance.Info(string.Format(message, args));
            }

        }

        public static void Warn(string message, params object[] args)
        {
            if (Instance == null)
            {
                Console.WriteLine(message, args);
            }
            else
            {
                Instance.Warn(string.Format(message, args));
            }
        }

        public static void Warn(Exception e, string message, params object[] args)
        {
            if (Instance == null)
            {
                Console.WriteLine(message, args);
            }
            else
            {
                Instance.WarnException(string.Format(message, args), e);
            }

        }

        public static void Error(Exception e)
        {
            if (Instance == null)
            {
                Console.WriteLine(e);
            }
            else
            {
                Instance.ErrorException(e.Message, e);
            }
        }

        public static void Error(string message, params object[] args)
        {
            if (Instance == null)
            {
                Console.WriteLine(message, args);
            }
            else
            {
                Instance.Error(string.Format(message, args));
            }
        }

        public static void Error(Exception e, string message, params object[] args)
        {
            if (Instance == null)
            {
                Console.WriteLine(string.Format(message, args) + e);
            }
            else
            {
                Instance.ErrorException(string.Format(message, args), e);
            }
        }

        public static void Write(string message, Severity severity)
        {
            switch (severity)
            {
                case Severity.Debug:
                    Debug(message);
                    break;
                case Severity.Info:
                    Info(message);
                    break;
                case Severity.Warning:
                    Warn(message);
                    break;
                case Severity.Error:
                    Error(message);
                    break;

            }
        }
    }
}
