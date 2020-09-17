using Microsoft.EntityFrameworkCore;
using SocialNetwork_2.Database.DbEntities;
using SocialNetwork_2.Database.EntityConfigurations;

namespace SocialNetwork_2.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());

            modelBuilder.Entity<Post>()
                .HasOne(o => o.Profile)
                .WithMany(m => m.Posts);
        }

    }
}
