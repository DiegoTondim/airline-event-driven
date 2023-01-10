using Airline.Basket;
using Airline.Basket.Models;
using Airline.Domain.Events;
using MassTransit;

namespace Airline.Payments.Consumers
{
    public class OrdersConsumer : IConsumer<OrderProcessed>
    {
        private readonly ILogger<OrdersConsumer> _logger;
        private readonly IBasketService _basketService;

        public OrdersConsumer(ILogger<OrdersConsumer> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        public Task Consume(ConsumeContext<OrderProcessed> context)
        {
            _basketService.CleanUp(context.Message.Session);
            _logger.LogInformation($"basket state cleanup: {context.Message.Id}");

            return Task.CompletedTask;
        }
    }
}

