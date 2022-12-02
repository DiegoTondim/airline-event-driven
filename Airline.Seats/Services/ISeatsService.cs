using System;
using Airline.Seats.Models;

namespace Airline.Seats.Services
{
	public interface ISeatsService
	{
        IEnumerable<Seat> GetSeats(string session);

        void SaveSeatPrice(string session, decimal price);
    }
}

