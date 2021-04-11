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
        public DbSet<InitialCalorieIntakeList> InitialCalorieIntakeLists { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Emailmodel> Emails { get; set; }

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
                Name = "Health_Enthusiast",
                NormalizedName = "HEALTH_ENTHUSIAST"
            }
            );

            builder.Entity<InitialCalorieIntakeList>()
                .HasData(
                new InitialCalorieIntakeList
                {
                    Id = 1,
                    Name = "Eggs",
                    Calories = 72
                }, new InitialCalorieIntakeList
                {
                    Id = 2,
                    Name = "Chocolate",
                    Calories = 598
                }, new InitialCalorieIntakeList
                {
                    Id = 3,
                    Name = "Mixed Baby Lettuce",
                    Calories = 20
                }, new InitialCalorieIntakeList
                {
                    Id = 4,
                    Name = "Macaroni And Cheese",
                    Calories = 400
                }, new InitialCalorieIntakeList
                {
                    Id = 5,
                    Name = "Mayonnaise",
                    Calories = 57
                }, new InitialCalorieIntakeList
                {
                    Id = 6,
                    Name = "Fast Food",
                    Calories = 836
                }, new InitialCalorieIntakeList
                {
                    Id = 7,
                    Name = "Arroz Rojo (Mexican Rice)",
                    Calories = 297
                }
                );
            builder.Entity<Meal>()
                .HasData(
                new Meal
                {
                    Id = 1,
                    Name = "Breakfast"
                    
                }, new Meal
                {
                    Id = 2,
                    Name = "Lunch"
                   
                }, new Meal
                {
                    Id = 3,
                    Name = "Dinner"
                    
                }, new Meal
                {
                    Id = 4,
                    Name = "Snack"                   
                }
                );
        }

        public DbSet<CalorieTracker.Models.SearchedFood> SearchedFood { get; set; }
    }
}
