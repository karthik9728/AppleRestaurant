using Apple.Services.ProductAPI.DTO.Product;
using Apple.Services.ProductAPI.Model;
using AutoMapper;

namespace Apple.Services.ProductAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
        }
    }
}
