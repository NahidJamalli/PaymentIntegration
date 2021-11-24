using System.ComponentModel;

namespace PaymentIntegration.Contexts
{
    public class NewPaymentContext
    {
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }
        [DisplayName("Card Holder")]
        public string CardHolder { get; set; }
        [DisplayName("Expiry Date")]
        public string CardExpiryDate { get; set; }
        public string Cvv { get; set; }
    }
}