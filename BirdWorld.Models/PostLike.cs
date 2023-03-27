using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models
{
    public class PostLike
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public int PostID { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
