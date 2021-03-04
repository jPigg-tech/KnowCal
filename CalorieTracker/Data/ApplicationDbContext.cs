using CalorieTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodDiary> FoodDiaries { get; set; }

        public DbSet<Goals> Goals { get; set; }
        public DbSet<Health_Enthusiast> Health_Enthusiasts { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Health Enthusiast",
                NormalizedName = "Health Enthusiast"
            }
            );
        }
    }
}
