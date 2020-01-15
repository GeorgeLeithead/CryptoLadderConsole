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
using System.Linq;

namespace CryptoLadder {
    internal class Program {
        static async Task Main (string[] args) {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.development.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            ApiAuthorization appAuthorization = new BusinessLogic.ApiAuthorization();
            configuration.GetSection("ApiAuthorization").Bind(appAuthorization);
            ConsoleColor defaultConsoleForegroundColor = Console.ForegroundColor;
            if (string.IsNullOrEmpty(appAuthorization.ApiKey)  || string.IsNullOrEmpty(appAuthorization.Sign))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("NO API Key or Secret.  Update appsettings.json with details");
                Console.ForegroundColor = defaultConsoleForegroundColor;
                return;
            }

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
                APIKeyInfo resultKeyInfo = await apiKeyInfo.CallApiAsync();
                //Console.WriteLine(resultKeyInfo.ToJson());
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
                    foreach (OrderResBase result in from LinearRungs rung in linearLadder
                                           where rung.Quantity > 0
                                           let apiOrderCreate = new OrderCreate()
                                           let result = apiOrderCreate.CallApi(orderSide, symbol, OrderTypeEnum.Limit, TimeInForceEnum.GoodTillCancel, rung.Quantity, rung.Price)
                                           select result)
                    {
                        if (result.RetCode != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Error: {result.RetMsg}");
                        }
                        else
                        {
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

            } catch (Exception e) {
                Console.WriteLine ("Exception: " + e.Message);
            }
        }
    }
}