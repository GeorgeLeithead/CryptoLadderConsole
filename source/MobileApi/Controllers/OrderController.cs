using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InternetWideWorld.CryptoLadder.MobileApi.Domain;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetWideWorld.CryptoLadder.MobileApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>Create an order</summary>
        [HttpPost]
        public string CreateOrder(Signature signature)
        {
            return $"Signature is ApiKey:{signature.ApiKey}, Sign:{signature.Sign}";
        }
    }
}
