using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BirdWorld.Models
{
    public class AppUser: IdentityUser
    {

        public String  FirstName{ get; set; }
        public String  LastName { get; set; }
        public String? ProfileUrl { get; set; }

       


    }
}
