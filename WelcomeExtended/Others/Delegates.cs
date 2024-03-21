using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");

        public static readonly ILogger fileLogger = LoggerHelper.GetFileLogger("Hello 2", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\log.txt");

        public static void Log(string error)
        {
            logger.LogError(error);
        }

        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }

        public static void Print()
        {
            if (logger is HashLogger hashLogger)
            {
                hashLogger.PrintAllLogMessages();
            }
        }

        public static void Print(int eventId)
        {
            if (logger is HashLogger hashLogger)
            {
                hashLogger.PrintLogMessage(eventId);
            }
        }

        public static void Delete(int eventId)
        {
            if (logger is HashLogger hashLogger)
            {
                hashLogger.DeleteLogMessage(eventId);
            }
        }

        public static void FileErrorLog(string error)
        {
            fileLogger.LogError(error);
        }

        public static void FileInfoLog(string info)
        {
            fileLogger.LogInformation(info);
        }
    }
}
