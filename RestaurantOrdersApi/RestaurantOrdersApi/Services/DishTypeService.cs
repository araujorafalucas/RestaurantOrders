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
    public class DishTypeService : IDishTypeService
    {
        private readonly AppDbContext Context = null;
        public DishTypeService(AppDbContext context)
        {
            Context = context;
        }
        public Task<DishType> GetActiveDishTypeById(int dishTypeId, int mealTimeId)
        {
            return Context.DishTypes.FirstOrDefaultAsync(dishType => dishType.DishTypeId == dishTypeId
                                                         && dishType.IsEnable
                                                         && dishType.Dishes.Any(dish => dish.MealTimes.Any(mealTime => mealTime.MealTimeId == mealTimeId)));
        }
    }
}
