namespace Airline.Domain
{
    public class Passenger
    {
        public string Name { get; set; }

        public IList<PassengerSeat> Seats { get; set; }
    }
}