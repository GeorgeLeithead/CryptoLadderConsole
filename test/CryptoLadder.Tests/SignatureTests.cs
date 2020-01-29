using InternetWideWorld.CryptoLadder.Shared.BusinessLogic;
using Xunit;

namespace CryptoLadder.Tests
{
    public class SignatureTests
    {
        [Theory]
        [InlineData("t7T0YlFnYXk0Fx3JswQsDrViLg1Gh3DUU5Mr", "api_key=B2Rou0PLPpGqcU0Vu2&leverage=100&symbol=BTCUSD&timestamp=1542434791000", "670e3e4aa32b243f2dedf1dafcec2fd17a440e71b05681550416507de591d908")]
        public void SignatureTest(string secret, string message, string expectedResult)
        {
            //When
            string actualResult = Signature.Create(secret, message);
            //Then
            Assert.Equal(expectedResult, actualResult);
        }
    }
}