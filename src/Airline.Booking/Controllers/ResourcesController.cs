using Airline.Domain.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Booking.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourcesController : ControllerBase
{
    private readonly ResourcesPublisherService _publisher;

    public ResourcesController(ResourcesPublisherService publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        await _publisher.PublishAsync();

        return Ok();
    }
}

