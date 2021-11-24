namespace Payment.DumDumPay.ResponseModels
{
    public class ConfirmPaymentResponse : BaseResponse
    {
        public ConfirmPaymentResult Result { get; set; }
    }

    public class ConfirmPaymentResult
    {
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string OrderId { get; set; }
        public string LastFourDigits { get; set; }
    }
}