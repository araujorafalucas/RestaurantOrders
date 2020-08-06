using RestaurantOrdersApi.RequestModels;
using RestaurantOrdersApi.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.ServicesInterfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> AddOrder(OrderRequest order);

        Task<List<OrderResponse>> GetOrders();

        Task<OrderResponse> GetOrderById(int id);
    }
}
