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
                    dest => dest.NhanhOrderId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore());

        }
    }
}
