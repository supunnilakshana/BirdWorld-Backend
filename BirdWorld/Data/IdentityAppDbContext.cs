using BirdWorld.Config;
using BirdWorld.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BirdWorld.Data
{
    public class IdentityAppDbContext : IdentityDbContext<AppUser>
    {
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options)
        {




        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(Constant.connectionString);


        }


    }
}
