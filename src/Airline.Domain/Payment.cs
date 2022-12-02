namespace Airline.Domain
{
    public class Payment
    {
        public PaymentType Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public PaymentStatus Status { get; set; }
    }
}