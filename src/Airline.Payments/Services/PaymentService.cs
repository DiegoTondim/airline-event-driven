using Airline.Basket.Models;
using Airline.Domain.Events;
using Airline.Payments.Models;
using MassTransit;

namespace Airline.Payments.Services
{
    public class PaymentService : IPaymentService
    {
        private static IDictionary<string, Order> _orders = new Dictionary<string, Order>();
        private readonly IPublishEndpoint _publisher;

        public PaymentService(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public void CreateOrder(CheckoutEvent @event)
        {
            if (!_orders.ContainsKey(@event.Basket.Session))
            {
                _orders[@event.Basket.Session] = new Order(@event.Basket.Session, @event.Basket.Id);
            }
            foreach (var item in @event.Basket.Products)
            {
                _orders[@event.Basket.Session].Items.Add(new OrderItem { Code = item.Code, Type = item.Type });
            }
        }

        public void Pay(string session)
        {
            if (_orders.ContainsKey(session))
            {
                _publisher.Publish(new OrderProcessed { Id = _orders[session].OrderId, Session = session });
                _orders.Remove(session);
            }
            else
            {
                throw new Exception("Oops, there is no pending order for you to pay :)");
            }
        }
    }
}
