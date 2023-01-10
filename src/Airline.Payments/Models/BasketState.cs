namespace Airline.Basket.Models
{
    public class BasketState
    {
        public string Id { get; set; }

        public string Session { get; set; }

        public IList<BasketItem> Products { get; set; }
    }
}