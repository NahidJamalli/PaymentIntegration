using System.Threading.Tasks;
using Payment.DumDumPay.RequestModels;
using Payment.DumDumPay.ResponseModels;
using Refit;

namespace Payment.DumDumPay.Interfaces
{
    public interface IDumDumPayApi
    {
        [Post("/payment/create")]
        Task<ApiResponse<CreatePaymentResponse>> CreateAsync(CreatePaymentRequest request);

        [Post("/payment/confirm")]
        Task<ApiResponse<ConfirmPaymentResponse>> ConfirmAsync(ConfirmPaymentRequest request);
    }
}