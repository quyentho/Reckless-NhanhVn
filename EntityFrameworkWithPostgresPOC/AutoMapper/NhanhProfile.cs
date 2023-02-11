using AutoMapper;
using EntityFrameworkWithPostgresPOC.Models;
using NhanhVn.Common.Models;

namespace EntityFrameworkWithPostgresPOC.AutoMapper
{
    internal class NhanhProfile : Profile
    {
        public NhanhProfile()
        {
            CreateMap<NhanhOrder, Order>()
                .ForMember(
                    dest => dest.NhanhId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore());

            CreateMap<NhanhBill, Order>()
                .ForMember(
                    dest => dest.NhanhId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.MoneyDiscount,
                    opt => opt.MapFrom(src => src.Discount))
                .ForMember(
                    dest => dest.CalcTotalMoney,
                    opt => opt.MapFrom(src => src.Money));

            CreateMap<NhanhOrderProduct, Product>()
                .ForMember(
                    dest => dest.NhanhProductId,
                    opt => opt.MapFrom(src => src.ProductId))
                ;
            CreateMap<NhanhBillProduct, Product>()
                .ForMember(
                    dest => dest.NhanhProductId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.ProductCode,
                    opt => opt.MapFrom(src => src.Code))
                ;

            CreateMap<KeyValuePair<string, NhanhBillProduct>, Product>()
                .ConstructUsing(
                (pair, context) => context.Mapper.Map<NhanhBillProduct, Product>(pair.Value));
        }
    }
}
