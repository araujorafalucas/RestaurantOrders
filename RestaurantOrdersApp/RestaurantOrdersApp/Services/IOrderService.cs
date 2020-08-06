using RestaurantOrdersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApp.Services
{
    public interface IOrderService
    {
        Task<List<OrderRequestModel>> GetOrders();
        Task<OrderRequestModel> AddOrder(OrderRequestModel orderRequest);
    }
}
