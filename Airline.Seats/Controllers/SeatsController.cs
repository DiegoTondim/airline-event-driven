using Airline.Seats.Models;
using Airline.Seats.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Seats.Controllers;

[ApiController]
[Route("[controller]")]
public class SeatsController : ControllerBase
{
    private readonly ISeatsService _seatsService;

    public SeatsController(ISeatsService seatsService)
    {
        _seatsService = seatsService;
    }

    [HttpGet]
    public IEnumerable<Seat> Get([FromHeader(Name = "x-booking-id")] string session)
    {
        return _seatsService.GetSeats(session);
    }
}

