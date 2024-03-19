using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;

        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
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
            var message = formatter(state, exception);

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;

                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);

            Console.WriteLine("- LOGGER -");
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {message}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();

            _logMessages[eventId.Id] = message;
        }

        public void PrintAllLogMessages()
        {
            Console.WriteLine("All log messages: \n");

            foreach (var message in _logMessages)
            {
                Console.WriteLine($"{message}");
            }
        }

        public void PrintLogMessage(int eventId)
        {
            if (_logMessages.ContainsKey(eventId))
            {
                Console.WriteLine($"Event ID: {eventId} corresponds to message: {_logMessages[eventId]}");
            }
            else
            {
                Console.WriteLine("Invalid event ID");
            }
        }

        public void DeleteLogMessage(int eventId)
        {
            if (_logMessages.ContainsKey(eventId))
            {
                _logMessages.Remove(eventId, out _);
            }
            else
            {
                Console.WriteLine("Invalid event ID");
            }
        }
    }
}
