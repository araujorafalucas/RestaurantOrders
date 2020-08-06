using Microsoft.EntityFrameworkCore;
using RestaurantOrdersApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<MealTime> MealTimes { get; set; }
        public DbSet<DishMealTime> DishesMealTimes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                        .HasMany(dish => dish.MealTimes)
                        .WithMany(mealTime => mealTime.Dishes)
                        .UsingEntity<DishMealTime>(
                                        dishMealTime => dishMealTime
                                            .HasOne(dishMealTime => dishMealTime.MealTime)
                                            .WithMany()
                                            .HasForeignKey("MealTimeId"),
                                        dishMealTime => dishMealTime
                                            .HasOne(dishMealTime => dishMealTime.Dish)
                                            .WithMany()
                                            .HasForeignKey("DishId"))
                        .ToTable("DishesMealTimes")
                        .HasKey(dishMealTime => new { dishMealTime.MealTimeId, dishMealTime.DishId });
        }
    }
}
