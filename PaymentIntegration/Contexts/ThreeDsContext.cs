namespace PaymentIntegration.Contexts
{
    public class ThreeDsContext
    {
        public ThreeDsContext(string paReq, string url, string method)
        {
            PaReq = paReq;
            Url = url;
            Method = method;
        }

        public string PaReq { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
    }
}