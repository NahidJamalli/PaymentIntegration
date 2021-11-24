using Microsoft.AspNetCore.Mvc.RazorPages;
using PaymentIntegration.Contexts;

namespace PaymentIntegration.Pages
{
    public class ThreeDS : PageModel
    {
        public ThreeDsContext ThreeDsContext { get; set; }
        
        public void OnGet(string paReq, string url, string method)
        {
            ThreeDsContext = new ThreeDsContext(paReq, url, method);
        }
    }
}