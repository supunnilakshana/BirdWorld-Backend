using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BirdWorld.Models
{
    public class Post
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
      
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public  AppUser User { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<PostLike> Likes { get; set; } = new List<PostLike>();


    }
}
