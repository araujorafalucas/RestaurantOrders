using RestaurantOrdersApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.ServicesInterfaces
{
    public interface IDishService
    {
        Task<List<Dish>> GetActivesDishesByDishTypeId(int dishTypeId);
        Task<List<Dish>> GetActivesDishesByDishTypeIdMealTimeId(int dishTypeId, int mealTimeId);
    }
}
