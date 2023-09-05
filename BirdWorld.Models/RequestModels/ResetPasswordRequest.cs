using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models.RequestModels
{
    public class ResetPasswordRequest
    {
        public string email { get; set; }
        public string token { get; set; }
        public string newPassword { get; set; }


    }
}
