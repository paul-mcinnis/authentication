using Microsoft.EntityFrameworkCore;
using Auth.Data.Models;

namespace Auth.Data
{
    public class AuthDbContext : DbContext
    {

        public virtual DbSet<User> User { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.ModelId).HasColumnName("user_id");
                entity.Property(e => e.UserName).HasColumnName("user_name");
                entity.HasIndex(e => e.UserName).IsUnique(true);
            });
        }
    }
}
