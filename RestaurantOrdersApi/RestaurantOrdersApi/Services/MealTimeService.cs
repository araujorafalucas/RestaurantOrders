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
    public class MealTimeService : IMealTimeService
    {
        private readonly AppDbContext Context = null;
        public MealTimeService(AppDbContext context)
        {
            Context = context;
        }
        public Task<MealTime> GetActiveMealTimeByDescription(string description)
        {
            return Context.MealTimes.FirstOrDefaultAsync(mealTime => mealTime.Description == description && mealTime.IsEnable);
        }
    }
}
