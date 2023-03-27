using AutoMapper;
using BirdWorld.Models;


namespace BirdWorld.Services.Profiles
{
    public class BirdProfile : Profile
    {
        public BirdProfile()
        {
            CreateMap<Bird, BirdDto>();
               /* .ForMember(des => des.Name,
                opt => opt.MapFrom(src => src.DisplayName));*/
        }
    }
}
