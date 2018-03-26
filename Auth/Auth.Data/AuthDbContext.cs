using Auth.Library.Models;
using Microsoft.EntityFrameworkCore;

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
                
                /// <summary>
                /// Don't forget to configure the default value in your db 
                /// </summary>
                entity.Property(e => e.DateCreated).HasColumnName("date_created");
                entity.Property(e => e.DateCreated).ValueGeneratedOnAdd();
                
                
                /// <summary>
                /// Don't forget to write the trigger to update the timestamp
                /// </summary>
                entity.Property(e => e.DateModified).HasColumnName("date_modified");
                entity.Property(e => e.DateModified).ValueGeneratedOnAddOrUpdate();
                
                entity.Property(e => e.UserName).HasColumnName("user_name");
                entity.HasIndex(e => e.UserName).IsUnique(true);

                entity.Property(e => e.PasswordDigest).HasColumnName("password_digest");
                entity.Property(e => e.PasswordSalt).HasColumnName("password_salt");
                
                entity.Property(e => e.IsActive).HasColumnName("active");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });
        }
    }
}
