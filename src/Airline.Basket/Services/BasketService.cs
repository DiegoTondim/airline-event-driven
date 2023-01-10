using Airline.Basket.Models;
using MassTransit;

namespace Airline.Basket.Services
{
    public class BasketService : IBasketService
    {
        private static IDictionary<string, BasketState> _state = new Dictionary<string, BasketState>();
        private readonly IPublishEndpoint _publisher;

        public BasketService(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public void AddItem(string session, string code, string type)
        {
            if (!_state.ContainsKey(session))
            {
                _state[session] = new BasketState(session);
            }

            if (_state[session].CheckedOut)
            {
                throw new Exception("Oops, you cannot update your basket!");
            }
            _state[session].Products.Add(new BasketItem { Code = code, Type = type });
        }

        public async Task Checkout(string session)
        {
            await _publisher.Publish(new CheckoutEvent { Basket = _state[session] });
            _state[session].CheckedOut = true;
        }

        public void CleanUp(string session)
        {
            _state.Remove(session);
        }
    }
}