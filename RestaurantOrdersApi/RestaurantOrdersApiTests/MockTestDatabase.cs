using RestaurantOrdersApi.Context;
using RestaurantOrdersApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersApiTests
{
    public class MockTestDatabase
    {
        public AppDbContext Context { get; private set; }
        public MockTestDatabase()
        {
            AppDbContextFactory appDbContextFactory = new AppDbContextFactory();
            Context = appDbContextFactory.CreateDbContext(null);
            DishTypesSeeder();
            DishesSeeder();
            MealTimesSeeder();
            DishesMealTimesSeeder();
            Context.SaveChanges();
        }

        private void MealTimesSeeder()
        {
            Context.MealTimes.Add(new MealTime()
            {
                Description = "morning",
                IsEnable = true
            });

            Context.MealTimes.Add(new MealTime()
            {
                Description = "night",
                IsEnable = true
            });
        }
        private void DishTypesSeeder()
        {
            Context.DishTypes.Add(new DishType()
            {
                Description = "entrée",
                Sequence = 1,
                IsEnable = true
            });

            Context.DishTypes.Add(new DishType()
            {
                Description = "side",
                Sequence = 2,
                IsEnable = true
            });

            Context.DishTypes.Add(new DishType()
            {
                Description = "drink",
                Sequence = 3,
                IsEnable = true
            });

            Context.DishTypes.Add(new DishType()
            {
                Description = "dessert",
                Sequence = 4,
                IsEnable = true
            });
        }
        private void DishesSeeder()
        {
            Context.Dishes.Add(new Dish()
            {
                Description = "eggs",
                DishTypeId = 1,
                IsEnable = true
            });

            Context.Dishes.Add(new Dish()
            {
                Description = "steak",
                DishTypeId = 1,
                IsEnable = true
            });

            Context.Dishes.Add(new Dish()
            {
                Description = "Toast",
                DishTypeId = 2,
                IsEnable = true
            });
            Context.Dishes.Add(new Dish()
            {
                Description = "potato",
                DishTypeId = 2,
                IsEnable = true
            });

            Context.Dishes.Add(new Dish()
            {
                Description = "coffee",
                DishTypeId = 3,
                IsEnable = true
            });
            Context.Dishes.Add(new Dish()
            {
                Description = "wine",
                DishTypeId = 3,
                IsEnable = true
            });
            Context.Dishes.Add(new Dish()
            {
                Description = "cake",
                DishTypeId = 4,
                IsEnable = true
            });

        }
        private void DishesMealTimesSeeder()
        {
            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 1,
                MealTimeId = 1,
                MaxAllowed = 1
            });

            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 3,
                MealTimeId = 1,
                MaxAllowed = 1
            });

            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 5,
                MealTimeId = 1,
                MaxAllowed = -1
            });

            //night
            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 2,
                MealTimeId = 2,
                MaxAllowed = 1
            });

            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 4,
                MealTimeId = 2,
                MaxAllowed = -1
            });

            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 6,
                MealTimeId = 2,
                MaxAllowed = 1
            });
            Context.DishesMealTimes.Add(new DishMealTime()
            {
                DishId = 7,
                MealTimeId = 2,
                MaxAllowed = 1
            });
        }

    }
}
