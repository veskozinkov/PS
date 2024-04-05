using DataLayer.Loggers;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace DataLayer.Helpers
{
    public static class DatabaseLogHelper
    {
        private static int _userId = -1;

        public static int GetUserId(this ILogger logger)
        {
            return _userId;
        }

        public static void SetUserId(this ILogger logger, int userId)
        {
            _userId = userId;
        }

        public static string toString(this DatabaseLog log)
        {
            return "Log: {\n  ID: " + log.Id +
                "\n  Logger name: " + log.LoggerName +
                "\n  Log level: " + log.LogLevel +
                "\n  Event ID: " + log.EventId +
                "\n  Log message: " + log.LogMessage +
                "\n}";
        }

        public static void LogUserAdded(this ILogger logger, string message, int? userId)
        {
            if (userId != null)
            {
                _userId = userId.Value;
            }

            logger.LogInformation(message);
        }
    }
}
