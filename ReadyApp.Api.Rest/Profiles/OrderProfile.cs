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
            CreateMap<AddOrderDto, Order>();

            CreateMap<Order, OrderDto>();
        }
    }
}