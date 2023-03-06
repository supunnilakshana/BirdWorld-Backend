using AutoMapper;
using BirdWorld.Models;
using BirdWorld.Services.AppServices.AppUserService;

namespace BirdWorld.Services.Profiles
{
    public class PostProfile : Profile
    {

        private readonly IMapper mapper;
        public PostProfile()
        {

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AppUserProfile>());
            mapper = configuration.CreateMapper();

            CreateMap<Post, PostDto>()
             .ForMember(des => des.User,
             opt => opt.MapFrom(src => setUser(src.UserId)));
        }

        private AppUserDto? setUser(String userID)
        {
            var userService = new AppUserService();

            return mapper.Map<AppUserDto>(userService.GetAppUser(userID));
        }
    }
}
