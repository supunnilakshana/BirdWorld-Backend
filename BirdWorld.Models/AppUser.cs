using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BirdWorld.Models
{
    public class AppUser: IdentityUser
    {

        public String  DisplayName{ get; set; }
        public String? ProfileUrl { get; set; }


    }
}
