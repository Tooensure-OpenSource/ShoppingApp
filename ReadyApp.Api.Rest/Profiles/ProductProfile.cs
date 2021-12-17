using AutoMapper;
using shoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductDto, Product>()
                .ForMember(
                    dest => dest.Name,
                    otp => otp.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Cost,
                    otp => otp.MapFrom(src => src.Cost));

            CreateMap<Product, ProductDto>()
                .ForMember(
                    dest => dest.Name,
                    otp => otp.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Cost,
                    otp => otp.MapFrom(src => src.Cost));
        }
    }
}