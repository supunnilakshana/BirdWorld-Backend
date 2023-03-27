using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

        public AppUserDto? User { get; set; }
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<PostLikeDto> Likes { get; set; } = new List<PostLikeDto>();
    }
}
