using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Helpers
{
    public static class DatabaseLogHelper
    {
        public static string toString(this DatabaseLog log)
        {
            return "Log: {\n  ID: " + log.Id +
                "\n  Logger name: " + log.LoggerName +
                "\n  Log level: " + log.LogLevel +
                "\n  Event ID: " + log.EventId +
                "\n  Log message: " + log.LogMessage +
                "\n}";
        }
    }
}
