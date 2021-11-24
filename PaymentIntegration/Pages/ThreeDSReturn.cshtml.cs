using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Payment.DumDumPay.Interfaces;
using Payment.DumDumPay.RequestModels;

namespace PaymentIntegration.Pages
{
    public class ThreeDSReturn : PageModel
    {
        private readonly IDumDumPayApi _dumDumPayApi;

        public ThreeDSReturn(IDumDumPayApi dumDumPayApi)
        {
            _dumDumPayApi = dumDumPayApi;
        }

        public string PaymentStatus { get; set; }
        public List<string> Errors { get; set; }
        
        public async Task<IActionResult> OnGet(string md, string paRes)
        {
            var transactionId = HttpContext.Session.GetString("transaction-id");
            var response = await _dumDumPayApi.ConfirmAsync(new ConfirmPaymentRequest(transactionId, paRes));

            if (response.StatusCode == HttpStatusCode.OK && response.Content?.Errors == null)
            {
                PaymentStatus = response.Content?.Result.Status;
            }
            else
            {
                Errors = response.Content?.Errors.Select(e => $"{e.Type}: {e.Message}").ToList();
            }

            return Page();
        }
    }
}