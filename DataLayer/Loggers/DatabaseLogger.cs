using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
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

                string message = formatter(state, exception);
                int IdIndex = message.IndexOf(" ID: ");

                if (IdIndex != -1)
                {
                    int UserId = int.Parse(message.Substring(message.IndexOf(" ID: ") + 5));
                    message = message.Remove(message.IndexOf(" ID: "));

                    context.Add<DatabaseLog>(new DatabaseLog()
                    {
                        UserId = UserId,
                        LoggerName = _name,
                        LogLevel = logLevel,
                        EventId = eventId.Id,
                        LogMessage = message,
                        LogDate = DateTime.Now
                    });
                }
                else
                {
                    context.Add<DatabaseLog>(new DatabaseLog()
                    {
                        LoggerName = _name,
                        LogLevel = logLevel,
                        EventId = eventId.Id,
                        LogMessage = message,
                        LogDate = DateTime.Now
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
