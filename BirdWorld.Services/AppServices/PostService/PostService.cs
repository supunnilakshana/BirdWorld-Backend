using BirdWorld.Data;
using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.PostService
{
    public class  PostService :IPostRepository
    {
        private readonly AppDbContext dbContext;

        public PostService(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public bool CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public bool DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post? GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
