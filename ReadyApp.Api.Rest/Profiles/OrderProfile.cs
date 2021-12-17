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
                    dest => dest.OrderItems,
                    otp => otp.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(
                    dest => dest.Id,
                    otp => otp.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.OrderItems,
                    otp => otp.MapFrom(src => src.OrderItems.Count()));
        }
    }
}