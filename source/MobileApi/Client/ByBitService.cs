using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InternetWideWorld.CryptoLadder.MobileApi.Domain;
using InternetWideWorld.CryptoLadder.Shared.Model;
using Microsoft.Extensions.Logging;

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

        public async Task<OrderResBase> PlaceOrder(OrderRequest orderRequest)
        {
            // TODO: Need to be able to construct URL, FORM bosy and also apply SIGNATURE
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, path + BusinessLogic.OrderCreate.GenerateQueryParameters(orderRequest));
            string postParams = BusinessLogic.OrderCreate.GenerateFormParameters(orderRequest);
            requestMessage.Content = new StringContent(postParams, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await this.Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<OrderResBase>(responseStream);
            }
        }
    }
}