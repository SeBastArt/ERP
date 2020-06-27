using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace ERP.Fixtures.Logging
{
    public class TestOutputLogger : ILogger
    {
        private readonly ITestOutputHelper _output;

        public TestOutputLogger(ITestOutputHelper output)
        {
            _output = output;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Error;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            _output.WriteLine($"{logLevel.ToString()} - {exception.Message} - {exception.StackTrace}");
        }
    }
}
