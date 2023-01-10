namespace Airline.Domain.Events
{
    public class OrderProcessed
    {
        public string Id { get; set; }

        public string Session { get; set; }
    }
}
