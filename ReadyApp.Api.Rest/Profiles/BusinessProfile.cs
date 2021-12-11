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
            CreateMap<AddBusinessDto, Business>();

            CreateMap<Business, BusinessDto>();
        }
    }
}