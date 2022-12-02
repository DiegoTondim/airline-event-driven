using System;
using Airline.Seats.Models;

namespace Airline.Seats.Services
{
	public class SeatsService : ISeatsService
	{
		public static IDictionary<string, decimal> CachedPrices { get; set; } = new Dictionary<string, decimal>();


		public SeatsService()
		{
		}

		public IEnumerable<Seat> GetSeats(string session) {
			if (!CachedPrices.ContainsKey(session))
				throw new Exception("session not found");

			var price = CachedPrices[session];

			var seatPos = new string[] { "a", "b", "c", "d", "e", "f" };
            foreach (var seat in Enumerable.Range(1, 33)) {
				foreach (var pos in seatPos)
					yield return new Seat($"{seat}{pos}", price);
			}
		}

        public void SaveSeatPrice(string session, decimal price)
        {
			CachedPrices[session] = price;
        }
    }
}

