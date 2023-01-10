using Airline.Payments.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult Post([FromHeader(Name = "x-booking-id")] string session)
        {
            _paymentService.Pay(session);

            return Ok();
        }
    }
}