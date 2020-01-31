using InternetWideWorld.CryptoLadder.ConsoleApp.Api;
using InternetWideWorld.CryptoLadder.ConsoleApp.Client;
using InternetWideWorld.CryptoLadder.Shared.Definitions;
using InternetWideWorld.CryptoLadder.Shared.Model;
using Xunit;

namespace CryptoLadder.Tests
{
    public class OrderCreateTests
    {
/*
        public Configuration Configuration { get; set; }
        const string apiKey = "kxLuuAAVVcmdcbihm1";
        const string apiSecret = "Ko9bPRk9y4AVm1rVjpRoEAQeghsecirqL1rk";
        const decimal userId = 109425;
        const SymbolEnum symbol = SymbolEnum.XRPUSD;
        const SideEnum buySide = SideEnum.Buy;
        const SideEnum sellSide = SideEnum.Sell;
        const OrderTypeEnum orderType = OrderTypeEnum.Limit;
        const double buyPrice = 0.2;
        const double sellPrice = 0.22;
        const int quantity = 1;
        const TimeInForceEnum timeInForce = TimeInForceEnum.GoodTillCancel;
        const OrderStatusEnum orderStatus = OrderStatusEnum.Created;

        const bool readOnly = false;
        const string note = "CryptoLadder";

        [Fact]
        public void BuyTestSync()
        {
            this.Configuration = Configuration.Default;
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                Configuration.Default.ApiKey.Add ("api_key", apiKey);
            }
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                Configuration.Default.ApiKey.Add ("sign", apiSecret);
            }

            OrderCreate apiOrderCreate = new OrderCreate();
            OrderResBase result = apiOrderCreate.CallApi(buySide, symbol, orderType, timeInForce, quantity, buyPrice);
            Assert.Equal(userId, result.Result.UserId);
            Assert.Equal(symbol.ToString(), result.Result.Symbol);
            Assert.Equal(buySide.ToString(), result.Result.Side);
            Assert.Equal(orderType.ToString(), result.Result.OrderType);
            Assert.Equal(buyPrice, result.Result.Price);
            Assert.Equal(quantity, result.Result.Qty);
            Assert.Equal(timeInForce.ToString(), result.Result.TimeInForce);
            Assert.Equal(orderStatus.ToString(), result.Result.OrderStatus);
        }

        [Fact]
        public async System.Threading.Tasks.Task BuyTestAsync()
        {
            this.Configuration = Configuration.Default;
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                Configuration.Default.ApiKey.Add ("api_key", apiKey);
            }
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                Configuration.Default.ApiKey.Add ("sign", apiSecret);
            }

            OrderCreate apiOrderCreate = new OrderCreate();
            OrderResBase result = await apiOrderCreate.CallApiAsync(buySide, symbol, orderType, timeInForce, quantity, buyPrice);
            Assert.Equal(userId, result.Result.UserId);
            Assert.Equal(symbol.ToString(), result.Result.Symbol);
            Assert.Equal(buySide.ToString(), result.Result.Side);
            Assert.Equal(orderType.ToString(), result.Result.OrderType);
            Assert.Equal(buyPrice, result.Result.Price);
            Assert.Equal(quantity, result.Result.Qty);
            Assert.Equal(timeInForce.ToString(), result.Result.TimeInForce);
            Assert.Equal(orderStatus.ToString(), result.Result.OrderStatus);
        }

        [Fact]
        public void SellTestSync()
        {
            this.Configuration = Configuration.Default;
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                Configuration.Default.ApiKey.Add ("api_key", apiKey);
            }
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                Configuration.Default.ApiKey.Add ("sign", apiSecret);
            }

            OrderCreate apiOrderCreate = new OrderCreate();
            OrderResBase result = apiOrderCreate.CallApi(sellSide, symbol, orderType, timeInForce, quantity, sellPrice);
            Assert.Equal(userId, result.Result.UserId);
            Assert.Equal(symbol.ToString(), result.Result.Symbol);
            Assert.Equal(sellSide.ToString(), result.Result.Side);
            Assert.Equal(orderType.ToString(), result.Result.OrderType);
            Assert.Equal(sellPrice, result.Result.Price);
            Assert.Equal(quantity, result.Result.Qty);
            Assert.Equal(timeInForce.ToString(), result.Result.TimeInForce);
            Assert.Equal(orderStatus.ToString(), result.Result.OrderStatus);
        }

        [Fact]
        public async System.Threading.Tasks.Task SellTestAsync()
        {
            this.Configuration = Configuration.Default;
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                Configuration.Default.ApiKey.Add ("api_key", apiKey);
            }
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                Configuration.Default.ApiKey.Add ("sign", apiSecret);
            }

            OrderCreate apiOrderCreate = new OrderCreate();
            OrderResBase result = await apiOrderCreate.CallApiAsync(sellSide, symbol, orderType, timeInForce, quantity, sellPrice);
            Assert.Equal(userId, result.Result.UserId);
            Assert.Equal(symbol.ToString(), result.Result.Symbol);
            Assert.Equal(sellSide.ToString(), result.Result.Side);
            Assert.Equal(orderType.ToString(), result.Result.OrderType);
            Assert.Equal(sellPrice, result.Result.Price);
            Assert.Equal(quantity, result.Result.Qty);
            Assert.Equal(timeInForce.ToString(), result.Result.TimeInForce);
            Assert.Equal(orderStatus.ToString(), result.Result.OrderStatus);
        }        
*/
    }
}
