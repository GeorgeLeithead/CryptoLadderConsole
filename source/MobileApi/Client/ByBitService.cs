using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InternetWideWorld.CryptoLadder.MobileApi.Domain;
using InternetWideWorld.CryptoLadder.Shared.Model;
using Microsoft.Extensions.Logging;
using SharedBusinessLogic = InternetWideWorld.CryptoLadder.Shared.BusinessLogic;

namespace InternetWideWorld.CryptoLadder.MobileApi.Client
{
    public class ByBitService
    {
        /// <summary>API path</summary>
        private readonly string path = "/v2/private/order/create";

        /// <summary>Logging API</summary>
        private readonly ILogger log;

        // <summary>Collection pool for Web services</summary>
        private readonly IHttpClientFactory clientFactory;

        public HttpClient Client { get; }

        public ByBitService(IHttpClientFactory factory, ILogger<ByBitService> logger)
        {
            this.log = logger;
            this.clientFactory = factory;
            this.Client = clientFactory.CreateClient();
            // Create a typed client
            this.Client.BaseAddress = new System.Uri("https://api-testnet.bybit.com");
            this.Client.DefaultRequestHeaders.Add("Accept", "application/json");
            this.Client.DefaultRequestHeaders.Add("User-Agent", "CryptoLadder");
        }

        public async Task<OrderResBase> PlaceOrder(OrderRequest order)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, path + BusinessLogic.OrderCreate.GenerateQueryParameters(order));
            string postParams = BusinessLogic.OrderCreate.GenerateFormParameters(order);
            requestMessage.Content = new StringContent(postParams, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await this.Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<OrderResBase>(responseStream);
            }
        }

        public async Task<List<OrderResBase>> PlaceOrder(LadderOrder order)
        {
            List<OrderResBase> results = new List<OrderResBase>();
            List<LinearRungs> linearLadder = SharedBusinessLogic.Ladder.Linear(order.StartPrice, order.EndPrice, order.Rungs, order.Quantity);
            foreach (LinearRungs linearRungs in linearLadder.Where(ll => ll.Quantity > 0))
            {
                OrderRequest linearOrder = new OrderRequest
                {
                    ApiKey = order.ApiKey,
                    Sign = order.Sign,
                    Currency = order.Currency,
                    Symbol = order.Symbol,
                    Side = order.Side,
                    OrderSide = order.OrderSide,
                    StartPrice = linearRungs.Price,
                    Quantity = linearRungs.Quantity
                };
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, path + BusinessLogic.OrderCreate.GenerateQueryParameters(linearOrder));
                string postParams = BusinessLogic.OrderCreate.GenerateFormParameters(linearOrder);
                requestMessage.Content = new StringContent(postParams, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await this.Client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    results.Add(await JsonSerializer.DeserializeAsync<OrderResBase>(responseStream));
                }
                Task.Delay(1000).Wait();
            }

            return results;
        }
    }
}