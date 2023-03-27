using AutoMapper;
using BirdWorld.Models;
using BirdWorld.Services.AppServices.AppUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.Profiles
{
    public class PostLikeProfile :Profile
    {

        private readonly IMapper mapper;
        public PostLikeProfile()
        {

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AppUserProfile>());
            mapper = configuration.CreateMapper();

            CreateMap<PostLike, PostLikeDto>()
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