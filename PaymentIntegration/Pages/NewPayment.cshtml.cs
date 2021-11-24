using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Payment.DumDumPay.Interfaces;
using Payment.DumDumPay.RequestModels;
using PaymentIntegration.Contexts;

namespace PaymentIntegration.Pages
{
    public class NewPayment : PageModel
    {
        private readonly IDumDumPayApi _dumDumPayApi;
        private readonly IMapper _mapper;

        public NewPayment(IDumDumPayApi dumDumPayApi,
            IMapper mapper)
        {
            _dumDumPayApi = dumDumPayApi;
            _mapper = mapper;
        }
        
        [BindProperty] 
        public NewPaymentContext PaymentContext { get; set; }

        public List<string> Errors { get; private set; }

        public async Task<ActionResult> OnPostAsync()
        {
            var createRequest = _mapper.Map<CreatePaymentRequest>(PaymentContext);
            var response = await _dumDumPayApi.CreateAsync(createRequest);

            if (response.IsSuccessStatusCode && response.Content?.Errors == null)
            {
                var urlParams = new
                {
                    paReq = response.Content?.Result.PaReq,
                    url = response.Content?.Result.Url,
                    method = response.Content?.Result.Method
                };
                
                HttpContext.Session.SetString("transaction-id", response.Content?.Result.TransactionId);
                return RedirectToPage("ThreeDS", urlParams);
            }

            if (response.StatusCode == HttpStatusCode.BadRequest || response.Content?.Errors != null)
            {
                Errors = response.Content?.Errors.Select(e => $"{e.Type}: {e.Message}").ToList();
            }
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Errors = new List<string> {"Unauthorized"};
            }
            
            return Page();
        }
    }
}