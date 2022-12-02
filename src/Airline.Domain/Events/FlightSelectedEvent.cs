using System;
namespace Airline.Domain.Events
{
	public class FlightSelectedEvent
	{
		public FlightSelectedEvent()
		{
		}

		public FlightSelectedEvent(string sessionId)
		{
			SessionId = sessionId;
			var rdn = new Random();
			Products = new Product[]
			{
                new Product("SEAT", rdn.Next(10, 20)),
				new Product("BAG", rdn.Next(15, 35)),
				new Product("FAST", rdn.Next(5, 10))
            };
		}

		public string SessionId { get; set; }

		public Product[] Products { get; set; }
	}

	public record Product(string Code, decimal Price);
}

