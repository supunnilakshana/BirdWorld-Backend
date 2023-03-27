using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models
{
    public class PostLikeDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public int PostID { get; set; }

        public string UserId { get; set; }
        public AppUserDto? User { get; set; }
    
    }
}
