using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Loggers
{
    internal class DatabaseLogger : ILogger
    {
        private readonly string _name;

        public DatabaseLogger(string name)
        {
            _name = name;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseLog>(new DatabaseLog()
                {
                    LoggerName = _name,
                    LogLevel = logLevel,
                    EventId = eventId.Id,
                    LogMessage = formatter(state, exception)
                });
                context.SaveChanges();
            }
        }
    }
}
