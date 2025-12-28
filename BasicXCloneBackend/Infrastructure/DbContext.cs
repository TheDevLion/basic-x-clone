using Microsoft.EntityFrameworkCore;
using BasicXCloneBackend.Domain.Entities;

namespace BasicXCloneBackend.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Repost> Repost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserName);
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Repost>()
                .HasKey(p => p.Id);
        }
    }
}

