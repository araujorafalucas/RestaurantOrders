using Microsoft.EntityFrameworkCore;
using RestaurantOrdersApi.Context;
using RestaurantOrdersApi.Entities;
using RestaurantOrdersApi.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Services
{
    public class DishMealTimeService : IDishMealTimeService
    {
        private readonly AppDbContext Context = null;
        public DishMealTimeService(AppDbContext context)
        {
            Context = context;
        }
        public Task<DishMealTime> GetDishMealTimeById(int dishId, int mealTimeId)
        {
            return Context.DishesMealTimes.FirstOrDefaultAsync(dishMealTime => dishMealTime.DishId == dishId && dishMealTime.MealTimeId == mealTimeId);
        }
    }
}
