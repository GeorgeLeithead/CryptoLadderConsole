namespace InternetWideWorld.CryptoLadder.ConsoleApp.Model
{
    /// <summary>Application settings model.</summary>
    public class AppSettings : IAppSettings
    {
        /// <summary>User identification API key.</summary>
        public string ApiKey { get; set; }
        /// <summary>User identification signature key.</summary>
        public string Sign { get; set; }
    }
}