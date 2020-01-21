using CryptoLadder.Api;
using CryptoLadder.Client;
using CryptoLadder.Model;
using Xunit;

namespace CryptoLadder.Tests
{
    public class ApiKeyInfoTests
    {
        public CryptoLadder.Client.Configuration Configuration { get; set; }
        const string apiKey = "kxLuuAAVVcmdcbihm1";
        const string apiSecret = "Ko9bPRk9y4AVm1rVjpRoEAQeghsecirqL1rk";
        const decimal userId = 109425;
        const bool readOnly = false;
        const string note = "CryptoLadder";

        [Fact]
        public void TestSync()
        {
            this.Configuration = CryptoLadder.Client.Configuration.Default;
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                Configuration.Default.ApiKey.Add ("api_key", apiKey);
            }
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                Configuration.Default.ApiKey.Add ("sign", apiSecret);
            }

            KeyInfo apiKeyInfo = new KeyInfo();
            APIKeyBase resultKeyInfo = apiKeyInfo.CallApi();
            Assert.Equal(apiKey, resultKeyInfo.Result[0].ApiKey, false, false, false);
            Assert.Equal(userId, resultKeyInfo.Result[0].UserId);
            Assert.Equal(readOnly, resultKeyInfo.Result[0].ReadOnly);
            Assert.Equal(note, resultKeyInfo.Result[0].Note, false, false, false);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestAsync()
        {
            this.Configuration = CryptoLadder.Client.Configuration.Default;
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                Configuration.Default.ApiKey.Add ("api_key", apiKey);
            }
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                Configuration.Default.ApiKey.Add ("sign", apiSecret);
            }

            KeyInfo apiKeyInfo = new KeyInfo();
            APIKeyBase resultKeyInfo = await apiKeyInfo.CallApiAsync();
            Assert.Equal(apiKey, resultKeyInfo.Result[0].ApiKey, false, false, false);
            Assert.Equal(userId, resultKeyInfo.Result[0].UserId);
            Assert.Equal(readOnly, resultKeyInfo.Result[0].ReadOnly);
            Assert.Equal(note, resultKeyInfo.Result[0].Note, false, false, false);
        }
    }
}
