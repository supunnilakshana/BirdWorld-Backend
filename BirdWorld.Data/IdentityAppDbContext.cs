﻿/*using BirdWorld.Config;
using BirdWorld.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BirdWorld.DataAcess
{
    public class IdentityAppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Post> Posts { get; set; }
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options)
        {




        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(Constant.connectionString);


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ((int)AppUserRoles.Admin).ToString(),
                    Name = AppUserRoles.Admin.ToString(),
                    NormalizedName = AppUserRoles.Admin.ToString().ToUpper(),
                },
                new IdentityRole
                {
                    Id = ((int)AppUserRoles.GUser).ToString(),
                    Name = AppUserRoles.GUser.ToString(),
                    NormalizedName = AppUserRoles.GUser.ToString().ToUpper()
                },
               new IdentityRole
               {
                   Id = ((int)AppUserRoles.Seller).ToString(),
                   Name = AppUserRoles.Seller.ToString(),
                   NormalizedName = AppUserRoles.Seller.ToString().ToUpper()
               }
            );

          
           builder.Entity<Post>()
           .HasOne(p => p.User)
           .WithMany()
           .HasForeignKey(p => p.UserId);

        }


    }
}
*/