using AutoMapper;
using Payment.DumDumPay.RequestModels;
using PaymentIntegration.Contexts;

namespace PaymentIntegration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NewPaymentContext, CreatePaymentRequest>();
        }
    }
}