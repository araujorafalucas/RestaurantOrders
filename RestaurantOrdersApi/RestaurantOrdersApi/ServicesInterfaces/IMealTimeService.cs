using RestaurantOrdersApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.ServicesInterfaces
{
    public interface IMealTimeService
    {
        Task<MealTime> GetActiveMealTimeByDescription(string description);
    }
}
