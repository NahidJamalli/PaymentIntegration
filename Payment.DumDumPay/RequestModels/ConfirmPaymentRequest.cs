namespace Payment.DumDumPay.RequestModels
{
    public class ConfirmPaymentRequest
    {
        public ConfirmPaymentRequest(string transactionId, string paRes)
        {
            TransactionId = transactionId;
            PaRes = paRes;
        }

        public string TransactionId { get; set; }
        public string PaRes { get; set; }
    }
}