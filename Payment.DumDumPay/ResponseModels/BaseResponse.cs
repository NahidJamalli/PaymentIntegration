using System.Collections.Generic;

namespace Payment.DumDumPay.ResponseModels
{
    public class BaseResponse
    {
        public List<ResultError> Errors { get; set; }
    }
    
    public class ResultError
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}