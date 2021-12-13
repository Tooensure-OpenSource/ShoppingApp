using AutoMapper;
using shoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AddOrderDto, Order>()
                .ForMember(
                    dest => dest.UserId,
                    otp => otp.MapFrom(src => src.UserId))
                .ForMember(
                    dest => dest.BuisnessId,
                    otp => otp.MapFrom(src => src.BusinessId))
                .ForMember(
                    dest => dest.OrderItems,
                    otp => otp.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(
                    dest => dest.Id,
                    otp => otp.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.UserId,
                    otp => otp.MapFrom(src => src.UserId))
                .ForMember(
                    dest => dest.BusinessId,
                    otp => otp.MapFrom(src => src.BuisnessId))
                .ForMember(
                    dest => dest.OrderItems,
                    otp => otp.MapFrom(src => src.OrderItems.Count()))
                .ForMember(
                    dest => dest.DateCreated,
                    otp => otp.MapFrom(src => src.DateCreated));
        }
    }
}