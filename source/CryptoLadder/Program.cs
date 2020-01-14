using System;
using CryptoLadder.Api;
using CryptoLadder.Client;
using CryptoLadder.Model;
using CryptoLadder.Definitions;
using CryptoLadder.BusinessLogic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoLadder {
    class Program {
        static void Main (string[] args) {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            ApiAuthorization appAuthorization = new BusinessLogic.ApiAuthorization();
            configuration.GetSection("ApiAuthorization").Bind(appAuthorization);

            SymbolEnum symbol = BusinessLogic.SymbolReader.Get();
            double startPrice = BusinessLogic.PriceReader.Get(true);
            double endPrice = BusinessLogic.PriceReader.Get(false);
            int ladderRungs = BusinessLogic.RungsReader.Get();
            int totalQuantity = BusinessLogic.QuantityReader.Get(ladderRungs);

            Configuration.Default.ApiKey.Add ("api_key", appAuthorization.ApiKey);
            Configuration.Default.ApiKey.Add ("sign", appAuthorization.Sign);

            var apiKeyInfo = new KeyInfo();
            try {
                // Get account api-key information.
                APIKeyInfo resultKeyInfo = apiKeyInfo.CallApi();
                Console.WriteLine(resultKeyInfo.ToJson());
                SideEnum orderSide = SideEnum.Buy;
                if (startPrice < endPrice)
                {
                    orderSide = SideEnum.Sell;
                }
                double gaps = Ladder.Calculate(startPrice, endPrice, ladderRungs);
                StringBuilder confirmation = new StringBuilder();
                confirmation.Append("ORDER DETAILS\n");
                confirmation.Append("=============\n");
                confirmation.Append($"Side: {orderSide}\n");
                confirmation.Append($"Symbol: {symbol}\n");
                confirmation.Append($"Order Type: {OrderTypeEnum.Limit}\n");
                confirmation.Append($"Time in force: {TimeInForceEnum.GoodTillCancel}\n");
                List<LinearRungs> linearLadder = BusinessLogic.Ladder.Linear(startPrice, endPrice, ladderRungs, totalQuantity);
                int totalOrderQuantity = 0;
                for(int rungs = 0; rungs < linearLadder.Count; rungs++)
                {
                    totalOrderQuantity += linearLadder[rungs].Quantity;
                    confirmation.Append($"\tRung {rungs+1}: {linearLadder[rungs].Quantity} @ {linearLadder[rungs].Price}\n");
                }

                confirmation.Append($"TOTAL Quantity: {totalOrderQuantity}\n");

                Console.WriteLine(confirmation);
                Console.Write("\n\nDo you want to execute this order?");
                var confirm = Console.ReadKey();
                if (confirm.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("PLACING ORDER......");
                    for(int rungs = 0; rungs < linearLadder.Count; rungs++)
                    {
                        OrderCreate apiOrderCreate = new OrderCreate();
                        OrderResBase result = apiOrderCreate.CallApi(orderSide, symbol, OrderTypeEnum.Limit, TimeInForceEnum.GoodTillCancel, linearLadder[rungs].Quantity, linearLadder[rungs].Price);
                        Console.WriteLine(result.ToJson());
                        Task.Delay(1000).Wait();
                    }

                    Console.WriteLine("Order(s) Placed!  Good luck!");
                }
                else
                {
                    Console.WriteLine("Order canceled! Good luck!");
                }
                

            } catch (Exception e) {
                Console.WriteLine ("Exception: " + e.Message);
            }
        }
    }
}