using Apple.Services.CouponAPI.DTO;
using Apple.Services.CouponAPI.Model;
using AutoMapper;

namespace Apple.Services.CouponAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon,CouponDto>().ReverseMap();
        }
    }
}
