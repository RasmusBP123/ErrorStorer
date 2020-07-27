using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Storage
{
    public class DbStorage : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbStorage(DbContextOptions<DbStorage> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>()
                   .Ignore(user => user.TwoFactorEnabled)
                   .Ignore(user => user.LockoutEnabled)
                   .Ignore(user => user.LockoutEnd)
                   .Ignore(user => user.PhoneNumberConfirmed)
                   .Ignore(user => user.EmailConfirmed)
                   .Ignore(user => user.AccessFailedCount);
           

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
