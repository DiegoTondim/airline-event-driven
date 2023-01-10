using Airline.Basket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(ILogger<BasketController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        public IActionResult Post(BasketItemRequest request, [FromHeader(Name = "x-booking-id")] string session)
        {
            _basketService.AddItem(session, request.Code, request.Type);

            return Ok();
        }
    }
}