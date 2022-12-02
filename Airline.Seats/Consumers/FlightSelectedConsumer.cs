using System;
using Airline.Domain.Events;
using Airline.Seats.Services;
using MassTransit;

namespace Airline.Seats.Consumers
{
    public class FlightSelectedConsumer : IConsumer<FlightSelectedEvent>
    {
        private readonly ISeatsService _seatsService;
        private readonly ILogger<FlightSelectedConsumer> _logger;

        public FlightSelectedConsumer(ISeatsService seatsService, ILogger<FlightSelectedConsumer> logger)
        {
            _seatsService = seatsService;
            _logger = logger;
        }

        public Task Consume(ConsumeContext<FlightSelectedEvent> context)
        {
            if (string.IsNullOrEmpty(context.Message.SessionId) || context.Message.Products == null)
            {
                _logger.LogError($"Invalid message, skipping it: session: {context.Message.SessionId}");
                return Task.CompletedTask;
            }

            _seatsService.SaveSeatPrice(context.Message.SessionId, context.Message.Products.First(x => x.Code == "SEAT").Price);
            _logger.LogInformation($"seats price updated for session: {context.Message.SessionId}");

            return Task.CompletedTask;
        }
    }
}

