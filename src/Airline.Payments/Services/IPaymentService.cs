using Airline.Basket.Models;

namespace Airline.Payments.Services
{
    public interface IPaymentService
    {
        void CreateOrder(CheckoutEvent @event);

        void Pay(string session);
    }
}
