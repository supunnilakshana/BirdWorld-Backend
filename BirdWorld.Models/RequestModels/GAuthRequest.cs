using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models.RequestModels
{
    public class GAuthRequest
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
