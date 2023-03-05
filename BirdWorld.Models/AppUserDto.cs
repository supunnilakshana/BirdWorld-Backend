using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models
{
    public class AppUserDto
    {
        public String Id { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }


    }
}
