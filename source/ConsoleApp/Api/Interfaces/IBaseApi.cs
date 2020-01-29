using InternetWideWorld.CryptoLadder.ConsoleApp.Client;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.Api.Interfaces
{
    /// <summary>Base API class</summary>
    public interface IBaseApi
    {
        /// <summary>Gets or sets the configuration object.</summary>
        /// <value>An instance of the Configuration</value>
        Configuration Configuration { get; set; }
        /// <summary>Provides a factory method hook for the creation of exceptions.</summary>
        ExceptionFactory ExceptionFactory { get; set; }

        /// <summary>Gets the base path of the API client.</summary>
        /// <value>The base path</value>
        string GetBasePath();
    }
}