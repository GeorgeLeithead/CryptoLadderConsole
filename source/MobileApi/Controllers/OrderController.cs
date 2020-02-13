using System.Net.Http;
using System.Threading.Tasks;
using InternetWideWorld.CryptoLadder.MobileApi.Client;
using InternetWideWorld.CryptoLadder.MobileApi.Domain;
using InternetWideWorld.CryptoLadder.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternetWideWorld.CryptoLadder.MobileApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>Logging API</summary>
        private readonly ILogger log;

        // <summary>Collection pool for Web services</summary>
        private readonly IHttpClientFactory clientFactory;

        private readonly ByBitService ByBitService;

        public OrderController(IHttpClientFactory factory, ILogger<OrderController> logger, ByBitService bybitService)
        {
            this.log = logger;
            this.clientFactory = factory;
            this.ByBitService = bybitService;
        }

        /// <summary>Create an order</summary>
        [HttpPost("Create", Name = "Create")]
        [Produces("application/json")]
        public async Task<ActionResult<OrderResBase>> CreateOrder(OrderRequest orderRequest)
        {
            return await this.ByBitService.PlaceOrder(orderRequest);
        }

        /// <summary>Create a laddered order.</summary>
        [HttpPost("Ladder", Name = "Ladder")]
        public IActionResult CreateLadder(LadderOrder order)
        {
            return Ok($"Ladder order");
        }
    }
}
