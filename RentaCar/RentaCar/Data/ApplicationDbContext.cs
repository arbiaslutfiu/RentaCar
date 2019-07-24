using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentaCar.Areas.Admin.Models;

namespace RentaCar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutoSallonUser>()
                       .HasKey(t => new { t.AutoSallonId, t.UserId });

            modelBuilder.Entity<AutoSallonUser>()
                .HasOne(pt => pt.AutoSallon)
                .WithMany(a => a.AutoSallonUsers)
                .HasForeignKey(pt => pt.AutoSallonId);

            modelBuilder.Entity<AutoSallonUser>()
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId);
        }
        
        public DbSet<Cars> Cars { get; set; }       
        public DbSet<AutoSallon>AutoSallons { get; set; }
        public DbSet<AutoSallonUser> AutoSallonUsers { get; set; }
    }
}
