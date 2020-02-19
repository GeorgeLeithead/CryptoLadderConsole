using InternetWideWorld.CryptoLadder.MobileApi.Domain;
using InternetWideWorld.CryptoLadder.Shared.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SharedBusinessLogic = InternetWideWorld.CryptoLadder.Shared.BusinessLogic;

namespace InternetWideWorld.CryptoLadder.MobileApi.Client
{
    public class ByBitService
    {
        /// <summary>API path</summary>
        private readonly string path = "/v2/private/order/create";

        /// <summary>Logging API</summary>
        private readonly ILogger log;

        // <summary>Collection pool for Web services to MainNet</summary>
        private readonly IHttpClientFactory clientFactoryMainNet;

        // <summary>Collection pool for Web services to TestNet</summary>
        private readonly IHttpClientFactory clientFactoryTestNet;

        public HttpClient ClientMainNet { get; }

        public HttpClient ClientTestNet { get; }

        public ByBitService(IHttpClientFactory factory, ILogger<ByBitService> logger)
        {
            log = logger;
            clientFactoryMainNet = factory;
            clientFactoryTestNet = factory;
            ClientMainNet = clientFactoryMainNet.CreateClient();
            // Create a typed client
            ClientMainNet.DefaultRequestHeaders.Add("Accept", "application/json");
            ClientMainNet.DefaultRequestHeaders.Add("User-Agent", "CryptoLadder");
            ClientMainNet.BaseAddress = new System.Uri("https://api.bybit.com");

            ClientTestNet = clientFactoryTestNet.CreateClient();
            // Create a typed client
            ClientTestNet.DefaultRequestHeaders.Add("Accept", "application/json");
            ClientTestNet.DefaultRequestHeaders.Add("User-Agent", "CryptoLadder");
            ClientTestNet.BaseAddress = new System.Uri("https://api-testnet.bybit.com");
        }

        public async Task<OrderResBase> PlaceOrder(OrderRequest order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            HttpClient requestClient = ClientTestNet;
            if (order.MainNet) {
                requestClient = ClientMainNet;
            }
            
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, path + BusinessLogic.OrderCreate.GenerateQueryParameters(order));
            string postParams = BusinessLogic.OrderCreate.GenerateFormParameters(order);
            requestMessage.Content = new StringContent(postParams, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await requestClient.SendAsync(requestMessage).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            using System.IO.Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<OrderResBase>(responseStream);
        }

        public async Task<List<OrderResBase>> PlaceOrder(LadderOrder order)
        {
            List<OrderResBase> results = new List<OrderResBase>();
            if (null == order)
            {
                return results;
            }

            List<LinearRungs> linearLadder = SharedBusinessLogic.Ladder.Linear(order.StartPrice, order.EndPrice, order.Rungs, order.Quantity);
            foreach (var (requestMessage, postParams) in from LinearRungs linearRungs in linearLadder.Where(ll => ll.Quantity > 0)
                                                         let linearOrder = new OrderRequest
                                                         {
                                                             ApiKey = order.ApiKey,
                                                             Sign = order.Sign,
                                                             Currency = order.Currency,
                                                             Symbol = order.Symbol,
                                                             Side = order.Side,
                                                             OrderSide = order.OrderSide,
                                                             StartPrice = linearRungs.Price,
                                                             Quantity = linearRungs.Quantity
                                                         }
                                                         let requestMessage = new HttpRequestMessage(HttpMethod.Post, path + BusinessLogic.OrderCreate.GenerateQueryParameters(linearOrder))
                                                         let postParams = BusinessLogic.OrderCreate.GenerateFormParameters(linearOrder)
                                                         select (requestMessage, postParams))
            {
                requestMessage.Content = new StringContent(postParams, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await ClientMainNet.SendAsync(requestMessage).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                using (System.IO.Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    results.Add(await JsonSerializer.DeserializeAsync<OrderResBase>(responseStream));
                }

                Task.Delay(1000).Wait();
            }

            return results;
        }
    }
}