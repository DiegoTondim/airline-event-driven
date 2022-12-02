using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Booking.Controllers;

[ApiController]
[Route("[controller]")]
public class AvailabilityController : ControllerBase
{
    private static readonly Flight[] Flights = new []{
        new Flight
        {
            Date = DateTime.Parse("2023-11-01 08:00"),
            Destination = "LONDON",
            Origin = "DUBLIN",
            Price = 89.90m
        },
        new Flight
        {
            Date = DateTime.Parse("2023-11-02 14:00"),
            Destination = "LISBON",
            Origin = "DUBLIN",
            Price = 59.90m
        },
        new Flight
        {
            Date = DateTime.Parse("2023-11-03 10:00"),
            Destination = "MADRID",
            Origin = "FARO",
            Price = 49.90m
        },
        new Flight
        {
            Date = DateTime.Parse("2023-11-01 09:00"),
            Destination = "DUBLIN",
            Origin = "LONDON",
            Price = 89.90m
        },
        new Flight
        {
            Date = DateTime.Parse("2023-11-10 08:00"),
            Destination = "PARIS",
            Origin = "DUBLIN",
            Price = 99.90m
        },
        new Flight
        {
            Date = DateTime.Parse("2023-11-11 08:00"),
            Destination = "DUBLIN",
            Origin = "PARIS",
            Price = 79.90m
        }};

    private readonly ILogger<AvailabilityController> _logger;

    public AvailabilityController(ILogger<AvailabilityController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Flight> Get()
    {
        return Flights;
    }
}

