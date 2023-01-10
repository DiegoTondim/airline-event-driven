using Airline.Basket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IBasketService _basketService;

        public CheckoutController(ILogger<CheckoutController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromHeader(Name = "x-booking-id")] string session)
        {
            await _basketService.Checkout(session);

            return Ok();
        }
    }
}