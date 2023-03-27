using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models.RequestModels
{
    public class PostLikeRequest
    {
        public int? Id { get; set; }
        public int PostID { get; set; }
        public string UserId { get; set; }
    }
}
