using BirdWorld.Models;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.PostService
{
    public interface IPostRepository
    {
        public List<Post>? GetAllPosts();

        public Post? GetPost(int id);

        public bool CreatePost(Post post);
        public bool UpdatePost(Post post);
        public bool DeletePost(int id);

    }
}
