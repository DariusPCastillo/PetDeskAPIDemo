using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Transactions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace PetDeskTests
{
    internal static class TestHelper
    {
        public static TransactionScope StartTransaction() => new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        public static IConfiguration GetConfig() => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private static IMemoryCache GetMemCache() => new MemoryCache(new MemoryCacheOptions());
        private static IHttpContextAccessor GethttpCtx() => Mock.Of<IHttpContextAccessor>();
        public static ILogger<T> GetLogger<T>(this ITestOutputHelper testOutputHelper)
        {
            var factory = LoggerFactory.Create(builder =>
            {
                builder.AddProvider(new TestLoggerProvider(testOutputHelper));
            });
            return factory.CreateLogger<T>();
        }


    }
}
