using System;
using System.Reflection;
using Airline.Domain.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Booking.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightSelectController : ControllerBase
{ 
    private readonly ILogger<FlightSelectController> _logger;
    private readonly IPublishEndpoint _publisher;

    public FlightSelectController(ILogger<FlightSelectController> logger, IPublishEndpoint publisher)
    {
        _logger = logger;
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> Post(FlightSelectCommand command)
    {
        var sessionId = Guid.NewGuid().ToString();

        await _publisher.Publish<FlightSelectedEvent>(new FlightSelectedEvent(sessionId));

        Response.Headers.Add("x-booking-id", sessionId);
        return Ok();
    }
}

