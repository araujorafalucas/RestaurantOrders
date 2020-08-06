using RestaurantOrdersApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApp.Models
{
    public class OrderRequest : IOrderRequest
    {
        public List<OrderRequestModel> Orders = new List<OrderRequestModel>();
        public OrderRequestModel Order = new OrderRequestModel();
        private readonly IOrderService OrderService = null;
        
        public OrderRequest(IOrderService orderService)
        {
            OrderService = orderService;
        }

        public async Task GetOrders()
        {
            Orders = await OrderService.GetOrders();
        }

        public async Task<OrderRequestModel> AddOrder(string input)
        {
            return await OrderService.AddOrder(new OrderRequestModel() { Input = input });  

        }

    }
}
