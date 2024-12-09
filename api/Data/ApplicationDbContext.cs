﻿using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Data
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Specs> Specs { get; set; }
        public DbSet<Job> Jobs { get; set; }

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

            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            builder.Entity<Motorcycle>().HasQueryFilter(m => !m.IsDeleted);
            builder.Entity<Specs>().HasQueryFilter(s => !s.IsDeleted);
            builder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<Job>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<Job>().Property(j => j.Cost).HasPrecision(19, 4);
        }
    }
}
