namespace CryptoLadder.BusinessLogic
{
    public class AppNet
    {
        public bool TestNet { get; set; }
    }

    public class ApiAuthorization
    {
        public string ApiKey { get; set; }
        public string Sign { get; set; }
    }
}