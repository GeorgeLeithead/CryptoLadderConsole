using InternetWideWorld.CryptoLadder.MobileApi.Client;
using InternetWideWorld.CryptoLadder.MobileApi.Domain;
using InternetWideWorld.CryptoLadder.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetWideWorld.CryptoLadder.MobileApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ByBitService ByBitService;

        public OrderController(ByBitService bybitService)
        {
            ByBitService = bybitService;
        }

        /// <summary>Create an order</summary>
        [HttpPost("Create", Name = "Create")]
        [Produces("application/json")]
        public async Task<ActionResult<OrderResBase>> CreateOrder(OrderRequest order)
        {
            return await ByBitService.PlaceOrder(order).ConfigureAwait(false);
        }

        /// <summary>Create a laddered order.</summary>
        [HttpPost("Ladder", Name = "Ladder")]
        [Produces("application/json")]
        public async Task<ActionResult<List<OrderResBase>>> CreateLadder(LadderOrder order)
        {
            return await ByBitService.PlaceOrder(order).ConfigureAwait(false);
        }
    }
}
