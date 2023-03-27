using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models.RequestModels
{
    public class ChangePasswordRequest
    {

        public string UserId{get; set;}
        public string oldPassword { get; set;}
        public string newPassword { get; set;}



    }
}
