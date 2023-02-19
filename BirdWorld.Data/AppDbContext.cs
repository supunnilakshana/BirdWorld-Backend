using BirdWorld.Config;
using BirdWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdWorld.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString =Constant.connectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
             .HasKey(p => p.Id);

            modelBuilder.Entity<Comment>()
           .HasOne(c => c.Post)
           .WithMany(p => p.Comments)
           .HasForeignKey(c => c.PostID)
           .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
