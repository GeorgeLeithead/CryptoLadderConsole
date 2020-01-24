using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoLadder.Api;
using CryptoLadder.BusinessLogic;
using CryptoLadder.Client;
using CryptoLadder.Definitions;
using CryptoLadder.Model;
using Microsoft.Extensions.Logging;

namespace CryptoLadder
{
    /// <summary>CryptoLadder startup runner class.</summary>
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        /// <summary>CryptoLadder Startup constructor</summary>
        public Startup(ILogger<Startup> logger)
        {
            _logger = logger;
        }

        /// <summary>Create a crypto ladder.</summary>
        public async Task CreateLadder(string apiKey, string apiSign)
        {
            _logger.LogInformation(0, "Starting creating CryptoLadder");
            ConsoleColor defaultConsoleForegroundColor = Console.ForegroundColor;

            SymbolEnum symbol = SymbolReader.Get();
            double startPrice = PriceReader.Get(true);
            double endPrice = PriceReader.Get(false);
            int ladderRungs = RungsReader.Get();
            int totalQuantity = QuantityReader.Get(ladderRungs);

            Configuration.Default.ApiKey.Add("api_key", apiKey);
            Configuration.Default.ApiKey.Add("sign", apiSign);

            KeyInfo apiKeyInfo = new KeyInfo();
            // Get account api-key information.
            APIKeyBase resultKeyInfo = await apiKeyInfo.CallApiAsync();
            _logger.LogDebug(0, resultKeyInfo.ToJson());
            SideEnum orderSide = SideEnum.Buy;
            if (startPrice < endPrice)
            {
                orderSide = SideEnum.Sell;
            }
            double gaps = Ladder.Calculate(startPrice, endPrice, ladderRungs);
            StringBuilder confirmation = new StringBuilder();
            confirmation.Append("\nORDER DETAILS\n");
            confirmation.Append("=============\n");
            confirmation.Append($"Side: {orderSide}\n");
            confirmation.Append($"Symbol: {symbol}\n");
            confirmation.Append($"Order Type: {OrderTypeEnum.Limit}\n");
            confirmation.Append($"Time in force: {TimeInForceEnum.GoodTillCancel}\n");
            List<LinearRungs> linearLadder = Ladder.Linear(startPrice, endPrice, ladderRungs, totalQuantity);
            int totalOrderQuantity = 0;
            for (int rungs = 0; rungs < linearLadder.Count; rungs++)
            {
                totalOrderQuantity += linearLadder[rungs].Quantity;
                confirmation.Append($"\tRung {rungs + 1}: {linearLadder[rungs].Quantity} @ {linearLadder[rungs].Price}\n");
            }

            confirmation.Append($"TOTAL Quantity: {totalOrderQuantity}\n");

            Console.WriteLine(confirmation);
            Console.Write("\n\nDo you want to execute this order?");
            ConsoleKeyInfo confirm = Console.ReadKey();
            if (confirm.Key == ConsoleKey.Y)
            {
                _logger.LogDebug(1, confirmation.ToString());
                Console.WriteLine("PLACING ORDER......");
                foreach (OrderResBase result in from LinearRungs rung in linearLadder
                                                where rung.Quantity > 0
                                                let apiOrderCreate = new OrderCreate()
                                                let result = apiOrderCreate.CallApi(orderSide, symbol, OrderTypeEnum.Limit, TimeInForceEnum.GoodTillCancel, rung.Quantity, rung.Price)
                                                select result)
                {
                    if (result.RetCode != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        _logger.LogError(1, result.RetMsg);
                    }
                    else
                    {
                        _logger.LogDebug(2, result.ToJson());
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Order submitted: {result.Result.Qty} @ {result.Result.Price}");
                        Task.Delay(1000).Wait();
                    }

                    Console.ForegroundColor = defaultConsoleForegroundColor;
                }

                Console.WriteLine("Order(s) Placed!  Good luck!");
            }
            else
            {
                Console.WriteLine("Order canceled! Good luck!");
            }
        }
    }
}