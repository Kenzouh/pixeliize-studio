using Microsoft.EntityFrameworkCore;
using woolly_friends.Models.Tables;

namespace woolly_friends.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserEmail).IsUnique();
            base.OnModelCreating(modelBuilder);
        }

    }
}
