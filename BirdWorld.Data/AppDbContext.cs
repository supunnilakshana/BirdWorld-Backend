using BirdWorld.Config;
using BirdWorld.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BirdWorld.DataAcess
{

    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Bird> Birds { get; set; }
         public DbSet<PostLike> PostLikes { get; set; }


        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
              .HasKey(p => p.Id);

            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.Entity<Comment>()
               .HasOne(p => p.User)
               .WithMany()
               .HasForeignKey(p => p.UserId);
            builder.Entity<Comment>()
               .HasOne(c => c.Post)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PostID)
               .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<PostLike>()
               .HasOne(p => p.User)
               .WithMany()
               .HasForeignKey(p => p.UserId);

            builder.Entity<PostLike>()
               .HasOne(l => l.Post)
               .WithMany(p => p.Likes)
               .HasForeignKey(c => c.PostID)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Bird>()
            .Property(b => b.Images)
             .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
        );

        }


    }

}






