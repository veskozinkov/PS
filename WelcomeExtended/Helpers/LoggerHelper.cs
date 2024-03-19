using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    internal static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }

        public static ILogger GetFileLogger(string categoryName, string fileName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new FileLoggerProvider(fileName));

            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
