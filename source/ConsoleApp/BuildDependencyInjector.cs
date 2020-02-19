using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

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
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(config);
            })
            .BuildServiceProvider();
        }
    }
}