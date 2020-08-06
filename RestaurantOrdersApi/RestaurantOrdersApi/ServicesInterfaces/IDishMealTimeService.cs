using RestaurantOrdersApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.ServicesInterfaces
{
    public interface IDishMealTimeService
    {
        Task<DishMealTime> GetDishMealTimeById(int dishId, int mealTimeId);
    }
}
