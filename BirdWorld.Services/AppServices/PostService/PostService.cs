using BirdWorld.DataAcess;
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

        public PostService() {
            this.dbContext = new AppDbContext();
        }

        public bool CreatePost(Post post)
        {
            try
            {
                dbContext.Add(post) ;
                ;
                dbContext.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool DeletePost(int id)
        {
            try
            {
                dbContext.Remove(new Post { Id=id});
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public List<Post>? GetAllPosts()
        {
            try
            {
               var list= dbContext.Posts.ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public Post? GetPost(int id)
        {
            try
            {
                var post = dbContext.Posts.FirstOrDefault(p => p.Id.Equals(id));
                return post;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public bool UpdatePost(Post post)
        {
            try
            {
                dbContext.Posts.Update(post);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }
    }
}
