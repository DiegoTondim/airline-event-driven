using Airline.Basket.Models;
using Airline.Payments.Services;
using MassTransit;

namespace Airline.Payments.Consumers
{
    public class CheckoutConsumer : IConsumer<CheckoutEvent>
    {
        private readonly ILogger<CheckoutConsumer> _logger;
        private readonly IPaymentService _paymentService;

        public CheckoutConsumer(ILogger<CheckoutConsumer> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        public Task Consume(ConsumeContext<CheckoutEvent> context)
        {
            if (string.IsNullOrEmpty(context.Message.Basket.Session))
            {
                _logger.LogError($"Invalid message, skipping it: session: {context.Message.Basket.Session}");
                return Task.CompletedTask;
            }
            _paymentService.CreateOrder(context.Message);
            _logger.LogInformation($"basket state updated for session: {context.Message.Basket.Session}");

            return Task.CompletedTask;
        }
    }
}

