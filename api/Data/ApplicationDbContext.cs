using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Data
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Specs> Specs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(w => w.Log(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles =
            [
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            ];

            builder.Entity<IdentityRole>()
                   .HasData(roles);

            builder.Entity<User>()
                   .HasQueryFilter(u => !u.IsDeleted);

            builder.Entity<RefreshToken>()
                   .HasOne(rt => rt.User)
                   .WithMany(u => u.RefreshTokens)
                   .IsRequired(false);

            builder.Entity<Motorcycle>()
                   .HasQueryFilter(m => !m.IsDeleted);

            builder.Entity<Image>()
                   .HasQueryFilter(i => !i.IsDeleted);

            builder.Entity<Image>()
                   .Property(i => i.ResourceType)
                   .HasConversion<string>();

            builder.Entity<Specs>()
                   .HasQueryFilter(s => !s.IsDeleted);

            builder.Entity<Comment>()
                   .HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<Comment>()
                   .HasOne(c => c.Motorcycle)
                   .WithMany(m => m.Comments)
                   .HasForeignKey(c => c.MotorcycleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                   .HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Job>()
                   .HasQueryFilter(j => !j.IsDeleted);

            builder.Entity<Job>()
                   .Property(j => j.Cost)
                   .HasPrecision(19, 4);

            builder.Entity<Job>()
                   .HasOne(j => j.Motorcycle)
                   .WithMany(m => m.Jobs)
                   .HasForeignKey(c => c.MotorcycleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Job>()
                   .HasOne(j => j.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
