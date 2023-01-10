namespace Airline.Basket
{
    public interface IBasketService
    {
        void AddItem(string session, string code, string type);
        Task Checkout(string session);
        void CleanUp(string session);
    }
}