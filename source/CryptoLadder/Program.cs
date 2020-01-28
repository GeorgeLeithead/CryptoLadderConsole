using CryptoLadder.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CryptoLadder
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.development.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));

            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                AppSettings appAuthorization = new AppSettings();
                configuration.GetSection("ApiAuthorization").Bind(appAuthorization);
                ConsoleColor defaultConsoleForegroundColor = Console.ForegroundColor;
                if (string.IsNullOrEmpty(appAuthorization.ApiKey) || string.IsNullOrEmpty(appAuthorization.Sign))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NO API Key or Secret.  Update appsettings.json with details");
                    Console.ForegroundColor = defaultConsoleForegroundColor;
                    return;
                }

                IServiceProvider servicesProvider = BuildDependencyInjector.BuildDi(configuration);
                using (servicesProvider as IDisposable)
                {
                    Startup startup = servicesProvider.GetRequiredService<Startup>();
                    await startup.CreateLadder(appAuthorization.ApiKey, appAuthorization.Sign);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                LogManager.Shutdown(); // Flush and stop internal timers/threads before application-exit
            }
        }
    }
}