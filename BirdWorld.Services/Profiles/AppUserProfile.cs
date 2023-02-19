using AutoMapper;
using BirdWorld.Models;


namespace BirdWorld.Services.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserDto>()
                .ForMember(des => des.Name,
                opt => opt.MapFrom(src => src.DisplayName));
        }
    }
}
