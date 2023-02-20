using BirdWorld.Data;
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

        public CommentService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreatComment(Comment post)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public Comment? GetComment(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
