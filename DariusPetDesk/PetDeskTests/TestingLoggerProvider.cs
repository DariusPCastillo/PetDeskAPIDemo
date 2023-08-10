using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace PetDeskTests
{
    internal class TestLogger : ILogger
    {
        private ITestOutputHelper testOutputHelper;
        private LoggerExternalScopeProvider loggerExternalScopeProvider = new LoggerExternalScopeProvider();

        public TestLogger(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
        public System.IDisposable BeginScope<TState>(TState state) => loggerExternalScopeProvider.Push(state);
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, System.Exception? exception, System.Func<TState, System.Exception, string> formatter)
        {
            if (exception is not null) testOutputHelper.WriteLine($"{exception.GetType().Name} : {exception.Message}");
            testOutputHelper.WriteLine(formatter(state, exception));
        }
    }

    internal class TestLoggerProvider : ILoggerProvider
    {
        private ITestOutputHelper testOutputHelper;

        public TestLoggerProvider(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
        public ILogger CreateLogger(string categoryName) => new TestLogger(testOutputHelper);

        public void Dispose() { }
    }
}
