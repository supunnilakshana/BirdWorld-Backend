using AutoMapper;
using BirdWorld.Models;
using BirdWorld.Services.AppServices.AppUserService;
using BirdWorld.Services.AppServices.CommentService;
using System.Collections.Generic;

namespace BirdWorld.Services.Profiles
{
    public class PostProfile : Profile
    {

        private readonly IMapper mapper;
        public PostProfile()
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppUserProfile>();
                cfg.AddProfile<CommentProfile>();

            }    );
            mapper = configuration.CreateMapper();

            CreateMap<Post, PostDto>()
             .ForMember(des => des.User,
             opt => opt.MapFrom(src => setUser(src.UserId)))
               .ForMember(des => des.Comments,
             opt => opt.MapFrom(src => setCommnet(src.Id)));
        }

        private AppUserDto? setUser(String userID)
        {
            var userService = new AppUserService();

            return mapper.Map<AppUserDto>(userService.GetAppUser(userID));
        }

        private List<CommentDto> setCommnet(int postID)
        {
            var commentService = new CommentService();
            var list=  commentService.GetPostComments(postID);
            if (list == null)
            {
                return new List<CommentDto>();
            }
            else
            {
                
                var mappedlist=mapper.Map<ICollection<CommentDto>>(list).ToList() ??new List<CommentDto>();
                return mappedlist;
            }
           
          
        }
    }
}
