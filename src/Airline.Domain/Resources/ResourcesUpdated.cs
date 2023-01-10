namespace Airline.Booking.Models
{
    public class ResourcesUpdated
    {
        public DateTime Updated { get; set; }

        public ResourcesUpdated()
        {
            Updated = DateTime.Now;
        }
    }
}
