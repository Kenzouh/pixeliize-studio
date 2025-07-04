using Microsoft.EntityFrameworkCore;
using woolly_friends.Models.Tables;

namespace woolly_friends.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // emails must be unique
            modelBuilder.Entity<User>().HasIndex(u => u.UserEmail).IsUnique();

            // user and additional info must have 1 to 1 relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.AdditionalUserInfo)
                .WithOne(ai => ai.User)
                .HasForeignKey<AdditionalUserInfo>(ai => ai.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdditionalUserInfo> AdditionalUserInfo { get; set; }
        public DbSet<Pet> Pets { get; set; }

    }
}
