using DataLayer.Database;
using DataLayer.Helpers;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace DataLayer.Loggers
{
    public class DatabaseLogger : ILogger
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
                    UserId = this.GetUserId(),
                    LoggerName = _name,
                    LogLevel = logLevel,
                    EventId = eventId.Id,
                    LogMessage = formatter(state, exception),
                    LogDate = DateTime.Now
                });
                this.SetUserId(-1);

                context.SaveChanges();
            }
        }
    }
}
