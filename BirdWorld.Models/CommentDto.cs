using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models
{
    public class CommentDto
    {
  
        public int Id { get; set; }
        public string Context { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public int PostID { get; set; }
       // public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUserDto User { get; set; }






    }
}
