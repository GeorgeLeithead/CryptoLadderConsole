using CryptoLadder.Api;
using CryptoLadder.BusinessLogic;
using CryptoLadder.Client;
using CryptoLadder.Definitions;
using CryptoLadder.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLadder
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.development.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            AppSettings appAuthorization = new AppSettings();
            configuration.GetSection("ApiAuthorization").Bind(appAuthorization);
            ConsoleColor defaultConsoleForegroundColor = Console.ForegroundColor;
            if (string.IsNullOrEmpty(appAuthorization.ApiKey) || string.IsNullOrEmpty(appAuthorization.Sign))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("NO API Key or Secret.  Update appsettings.json with details");
                Console.ForegroundColor = defaultConsoleForegroundColor;
                return;
            }

            SymbolEnum symbol = SymbolReader.Get();
            double startPrice = PriceReader.Get(true);
            double endPrice = PriceReader.Get(false);
            int ladderRungs = RungsReader.Get();
            int totalQuantity = QuantityReader.Get(ladderRungs);

            Configuration.Default.ApiKey.Add("api_key", appAuthorization.ApiKey);
            Configuration.Default.ApiKey.Add("sign", appAuthorization.Sign);

            KeyInfo apiKeyInfo = new KeyInfo();
            try
            {
                // Get account api-key information.
                APIKeyBase resultKeyInfo = await apiKeyInfo.CallApiAsync();
                Console.WriteLine(resultKeyInfo.ToJson());
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

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}