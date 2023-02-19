using AutoMapper;
using BirdWorld.Models;

namespace BirdWorld.Profiles
{
    public class AppUserProfile : Profile
    {

        public AppUserProfile(String Role)
        {
            CreateMap<AppUser, AppUserDto>()
                .ForMember(des => des.Name,
                opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(des => des.Role,
                opt => opt.MapFrom(Role));
        }

    }
}
