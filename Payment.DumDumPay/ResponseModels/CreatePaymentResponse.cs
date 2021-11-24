using System.Collections.Generic;

namespace Payment.DumDumPay.ResponseModels
{
    public class CreatePaymentResponse : BaseResponse
    {
        public Result Result { get; set; }
    }

    public class Result
    {
        public string TransactionId { get; set; }
        public string TransactionStatus { get; set; }
        public string PaReq { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
    }

    
}