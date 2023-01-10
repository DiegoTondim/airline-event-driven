using Airline.Booking.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Airline.Domain.Resources
{
    public class ResourcesConsumer : IConsumer<ResourcesUpdated>
    {
        private readonly ILogger<ResourcesConsumer> _logger;

        public ResourcesConsumer(ILogger<ResourcesConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ResourcesUpdated> context)
        {
            _logger.LogInformation($"consuming resources event: {context.Message.Updated}");

            return Task.CompletedTask;
        }
    }
}

