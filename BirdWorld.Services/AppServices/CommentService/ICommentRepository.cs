using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.CommentService
{
    public interface ICommentRepository
    {
        public List<Comment> GetAllComments();

        public Comment? GetComment(int id);

        public bool CreatComment(Comment post);
        public bool DeleteComment(int id);
        public bool UpdateComment(Comment comment);


    }
}
