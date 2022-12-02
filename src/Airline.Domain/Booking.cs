namespace Airline.Domain;
public class Booking
{
    public string PNR { get; set; }

    public IList<Passenger> Passengers { get; set; }

    public IList<Journey> Journeys { get; set; }

    public IList<Payment> Payments { get; set; }
}

