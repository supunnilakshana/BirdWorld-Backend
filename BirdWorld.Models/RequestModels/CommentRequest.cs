using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models.RequestModels
{
    public class CommentRequest
    {
        public int? Id { get; set; }
        public string Context { get; set; }
        public int PostID { get; set; }
        public string UserId { get; set; }
    }


}
