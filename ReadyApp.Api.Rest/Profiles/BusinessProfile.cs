using AutoMapper;
using shoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<AddBusinessDto, Business>()
                .ForMember(
                    dest => dest.Name,
                    otp => otp.MapFrom(src => src.Name));

            CreateMap<Business, BusinessDto>()
                .ForMember(
                    dest => dest.Products,
                    otp => otp.MapFrom(src => src.Products.Count())) 
                .ForMember(
                    dest => dest.Orders,
                    otp => otp.MapFrom(src => src.Orders.Count())) 
                .ForMember(
                    dest => dest.Users,
                    otp => otp.MapFrom(src => src.Users.Count()))            
                .ForMember(
                    dest => dest.Id,
                    otp => otp.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Name,
                    otp => otp.MapFrom(src => src.Name));
        }
    }
}