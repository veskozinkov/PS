using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Loggers;
using Microsoft.Extensions.Logging;

namespace DataLayer.Helpers
{
    internal class LoggerHelper
    {
        public static ILogger GetDatabaseLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new DatabaseLoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
