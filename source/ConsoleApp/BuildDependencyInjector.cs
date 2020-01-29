using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace InternetWideWorld.CryptoLadder.ConsoleApp
{
    /// <summary>Dependency injector container.</summary>
    public static class BuildDependencyInjector
    {
        internal static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
            .AddTransient<Startup>()
            .AddLogging(loggingBuilder =>
            {
            // configure NLog logging
            loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(config);
            })
            .BuildServiceProvider();
        }
    }
}