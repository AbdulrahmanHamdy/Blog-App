using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class AppBDContext : DbContext
    {
        public AppBDContext(DbContextOptions<AppBDContext> options) : base(options)
        {
        }
        public DbSet<Models.Post> Posts { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Post>()
                .HasOne(p => p.categor)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Models.Comment>()
                .HasOne(c => c.post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.postId);
        }
    }
}
