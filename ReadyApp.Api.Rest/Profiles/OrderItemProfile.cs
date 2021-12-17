using AutoMapper;
using ShoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<AddOrderItemDto, OrderItem>()
                .ForMember(
                    dest => dest.Quantity,
                    otp => otp.MapFrom(src => src.Quantity));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(
                    dest => dest.OrderItemId,
                    otp => otp.MapFrom(src => src.Id))                  
                .ForMember(
                    dest => dest.Quantity,
                    otp => otp.MapFrom(src => src.Quantity));
        }
    }
}