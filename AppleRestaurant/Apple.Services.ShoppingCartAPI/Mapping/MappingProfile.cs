using Apple.Services.ShoppingCartAPI.DTO;
using Apple.Services.ShoppingCartAPI.DTO.Products;
using Apple.Services.ShoppingCartAPI.Model;
using AutoMapper;

namespace Apple.Services.ShoppingCartAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CardHeader,CardHeaderDto>().ReverseMap();
            CreateMap<CardDetails,CardDetailsDto>().ReverseMap();
        }
    }
}
