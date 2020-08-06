using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApp.Models
{
    public interface IOrderRequest
    {
        Task GetOrders();

        Task<OrderRequestModel> AddOrder(string input);
    }
}
