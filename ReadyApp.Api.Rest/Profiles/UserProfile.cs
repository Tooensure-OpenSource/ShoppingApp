using AutoMapper;
using shoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming.UpdateDto;
using ShoppingApp.Data.DTOs.UserDto;

namespace ReadyApp.Api.Rest.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserUpdateDto>()
                .ForMember(
                    dest => dest.FirstName,
                    otp => otp.MapFrom(src => src.FristName))
                .ForMember(
                    dest => dest.LastName,
                    otp => otp.MapFrom(src => src.LastName));
            CreateMap<UserUpdateDto, User>()
                .ForMember(
                    dest => dest.FristName,
                    otp => otp.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    otp => otp.MapFrom(src => src.LastName));

            CreateMap<AddUserDto, User>()
                .ForMember(
                    dest => dest.FristName,
                    otp => otp.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    otp => otp.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.EmailAddress,
                    otp => otp.MapFrom(src => src.EmailAddress));

            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.Id,
                    otp => otp.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.FirstName,
                    otp => otp.MapFrom(src => src.FristName))
                .ForMember(
                    dest => dest.LastName,
                    otp => otp.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.EmailAddress,
                    otp => otp.MapFrom(src => src.EmailAddress))
                .ForMember(
                    dest => dest.DateCreated,
                    otp => otp.MapFrom(src => src.DateCreated))
                .ForMember(
                    dest => dest.Orders,
                    otp => otp.MapFrom(src => src.Orders.Count()))
                .ForMember(
                    dest => dest.Businesses,
                    otp => otp.MapFrom(src => src.Businesses.Count()));
                
        }
    }
}
// UserUpdateDto