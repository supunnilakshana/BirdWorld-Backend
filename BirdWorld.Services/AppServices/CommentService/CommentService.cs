
using BirdWorld.DataAcess;
using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.CommentService
{
    public class CommentService:ICommentRepository
    {
        private readonly AppDbContext dbContext;

        public CommentService()
        {
            this.dbContext = new AppDbContext();
        }

        public bool CreatComment(Comment comment)
        {
            try
            {
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool DeleteComment(int id)
        {
            try
            {
                dbContext.Remove(new Comment { Id = id });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public List<Comment>? GetAllComments()
        {
            try
            {
                var list = dbContext.Comments.ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public Comment? GetComment(int id)
        {
            try
            {
                var comment = dbContext.Comments.FirstOrDefault(c => c.Id.Equals(id));
                return comment;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public List<Comment>? GetPostComments(int id)
        {
            try
            {
                var list = dbContext.Comments.Where(c=> c.PostID==id).ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public bool UpdateComment(Comment comment)
        {
            try
            {
                var res = dbContext.Comments
                    .Update(comment);
                Console.WriteLine(res);
                dbContext.SaveChanges();
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
