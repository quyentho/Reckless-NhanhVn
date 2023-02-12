using AutoMapper;
using NhanhVn.Common.Enums;
using NhanhVn.Common.Models;
using NhanhVn.EntityFramework.Models;

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
                    dest => dest.Id,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.MoneyDiscount,
                    opt => opt.MapFrom(src => src.Discount))
                .ForMember(
                    dest => dest.CalcTotalMoney,
                    opt => opt.MapFrom(src => src.Money));

            CreateMap<NhanhOrderProduct, OrderProduct>()
                .ForMember(
                    dest => dest.NhanhProductId,
                    opt => opt.MapFrom(src => src.ProductId))
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore())

                ;
            CreateMap<NhanhBillProduct, OrderProduct>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore())
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

            CreateMap<KeyValuePair<string, NhanhBillProduct>, OrderProduct>()
                .ConstructUsing(
                (pair, context) => context.Mapper.Map<NhanhBillProduct, OrderProduct>(pair.Value));

            CreateMap<NhanhProduct, OrderProduct>()
                .ForMember(
                dest => dest.NhanhProductId,
                opt => opt.MapFrom(src => src.IdNhanh))
                .ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.ProductCode,
                    opt => opt.MapFrom(src => src.Code))
                ;
            CreateMap<NhanhProductInventory, ProductInventory>();
            CreateMap<NhanhProduct, Product>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore());
                ;
        }
    }
}
