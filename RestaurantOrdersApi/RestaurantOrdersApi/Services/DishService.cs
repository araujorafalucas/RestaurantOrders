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
    public class DishService : IDishService
    {
        private readonly AppDbContext Context = null;
        public DishService(AppDbContext context)
        {
            Context = context;
        }

        public Task<List<Dish>> GetActivesDishesByDishTypeId(int dishTypeId)
        {
            return Context.Dishes.Where(dish => dish.DishTypeId == dishTypeId && dish.IsEnable).ToListAsync();
        }

        public async Task<List<Dish>> GetActivesDishesByDishTypeIdMealTimeId(int dishTypeId, int mealTimeId)
        {
            return await (from dishes in Context.Dishes.Include(dish => dish.DishType).AsNoTracking()
                          join types in Context.DishTypes.AsNoTracking()
                            on dishes.DishTypeId equals types.DishTypeId
                          join dishMealTimes in Context.DishesMealTimes.AsNoTracking()
                            on dishes.DishId equals dishMealTimes.DishId
                          where
                             types.DishTypeId == dishTypeId
                             && dishMealTimes.MealTimeId == mealTimeId
                             && types.IsEnable
                             && dishes.IsEnable
                          select dishes).ToListAsync();
        }
    }
}
