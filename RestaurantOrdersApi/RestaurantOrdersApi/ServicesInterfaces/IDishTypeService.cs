using RestaurantOrdersApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.ServicesInterfaces
{
    public interface IDishTypeService
    {
        Task<DishType> GetActiveDishTypeById(int dishTypeId, int mealTimeId);
    }
}
