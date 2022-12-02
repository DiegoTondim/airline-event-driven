namespace Airline.Booking;

public class Flight
{
    public DateTime Date { get; set; }

    public decimal Price { get; set; }

    public string Origin { get; set; }

    public string Destination { get; set; }

    public int Left { get; set; } = 189;

    public string Key => $"{Date}-{Origin}-{Destination}-{Price}";
}

