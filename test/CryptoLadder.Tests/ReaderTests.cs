using InternetWideWorld.CryptoLadder.Shared.BusinessLogic;
using Xunit;

namespace CryptoLadder.Tests
{
    public class ReaderTests
    {
        [Theory]
        [InlineData("0.0001")]
        [InlineData("1000000")]
        [InlineData("1.2345")]
        [InlineData("1234")]
        public void ValidPriceTests(string price)
        {
            // When
            bool actualResult = PriceReader.IsPriceValid(price);
            // Then
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("0")]
        [InlineData("0.00009")]
        [InlineData("1000001")]
        [InlineData("")]
        public void InvalidPriceTests(string price)
        {
            // When
            bool actualResult = PriceReader.IsPriceValid(price);
            // Then
            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("2", 1)]
        [InlineData("1000", 37)]
        [InlineData("100000000", 10)]
        [InlineData("37", int.MinValue)]
        public void ValidQuantityTests(string quantity, int rungs)
        {
            // When
            bool actualResult = QuantityReader.IsQuantityValid(quantity, rungs);
            // Then
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("1", 2)]
        [InlineData("1000", 1001)]
        [InlineData("100000001", 10)]
        [InlineData("A", 2)]
        [InlineData("", 2)]
        [InlineData("37", int.MaxValue)]
        public void InvalidQuantityTests(string quantity, int rungs)
        {
            // When
            bool actualResult = QuantityReader.IsQuantityValid(quantity, rungs);
            // Then
            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("3")]
        [InlineData("99")]
        [InlineData("37")]
        public void ValidRungTests(string rungs)
        {
            // When
            bool actualResults = RungsReader.IsRungsValid(rungs);
            // Then
            Assert.True(actualResults);
        }

        [Theory]
        [InlineData("2")]
        [InlineData("100")]
        [InlineData("A")]
        [InlineData("")]
        public void InvalidRungTests(string rungs)
        {
            // When
            bool actualResults = RungsReader.IsRungsValid(rungs);
            // Then
            Assert.False(actualResults);
        }

        [Theory]
        [InlineData("BTC")]
        [InlineData("ETH")]
        [InlineData("EOS")]
        [InlineData("XRP")]
        [InlineData("xrp")]
        public void ValidCurrencySymbolTests(string currency)
        {
            // When
            bool actualResults = SymbolReader.IsSymbolValid(currency);
            // Then
            Assert.True(actualResults);
        }

        [Theory]
        [InlineData("BTCA")]
        [InlineData("btca")]
        [InlineData("A")]
        [InlineData("")]
        [InlineData("BSV")]
        public void InvalidCurrencySymbolTests(string currency)
        {
            // When
            bool actualResults = SymbolReader.IsSymbolValid(currency);
            // Then
            Assert.False(actualResults);
        }
    }
}