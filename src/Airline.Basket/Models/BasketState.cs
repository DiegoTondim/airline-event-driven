namespace Airline.Basket.Models
{
    public class BasketState
    {
        public string Id { get; set; }

        public string Session { get; set; }

        public IList<BasketItem> Products { get; set; }
        public bool CheckedOut { get; set; }

        public BasketState(string session)
        {
            Session = session;
            Id = Guid.NewGuid().ToString();
            Products = new List<BasketItem>();
        }
    }
}