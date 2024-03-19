using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly string _name;

        private readonly string _filePath;

        public FileLogger(string name, string filePath)
        {
            _name = name;
            _filePath = filePath;
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
            string[] fileLog =
            {
                $"Logger name: {_name}",
                $"Log level: {logLevel}",
                $"Event ID: {eventId.Id}",
                $"Log message: {formatter(state, exception)}\n"
            };

            try
            {
                File.AppendAllLines(_filePath, fileLog);
                Console.WriteLine("Log saved to file successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
