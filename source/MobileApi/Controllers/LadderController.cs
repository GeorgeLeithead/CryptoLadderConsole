using InternetWideWorld.CryptoLadder.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SharedBusinessLogic = InternetWideWorld.CryptoLadder.Shared.BusinessLogic;

namespace InternetWideWorld.CryptoLadder.MobileApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LadderController : ControllerBase
    {
        /// <summary>Get the generated ladder details.</summary>
        [HttpGet]
        public static List<LinearRungs> Get(double startPrice, double endPrice, int ladderRungs, int totalQuantity)
        {
            return SharedBusinessLogic.Ladder.Linear(startPrice, endPrice, ladderRungs, totalQuantity);
        }
    }
}
