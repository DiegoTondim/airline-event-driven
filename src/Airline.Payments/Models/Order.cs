using MassTransit.Futures.Contracts;

namespace Airline.Payments.Models
{
    public class Order
    {
        public string Session { get; set; }
        public string OrderId { get; set; }

        public IList<OrderItem> Items { get; set; }

        public Order(string session, string orderId)
        {
            Session = session;
            OrderId = orderId;
            Items = new List<OrderItem>();
        }
    }
}
