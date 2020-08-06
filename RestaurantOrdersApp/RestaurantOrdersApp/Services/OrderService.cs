using Newtonsoft.Json;
using RestaurantOrdersApp.Models;
using RestaurantOrdersApp.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestaurantOrdersApp.Services
{
    public class OrderService : IOrderService
    {
        public async Task<OrderRequestModel> AddOrder(OrderRequestModel orderRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10);
                StringContent postContent = new StringContent(JsonConvert.SerializeObject(orderRequest), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new UriBuilder($"{SystemInformation.ApiAddress}/api/orders").Uri, postContent);

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<OrderRequestModel>(content);

            }
        }

        public async Task<List<OrderRequestModel>> GetOrders()
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10);                
                var response = await client.GetAsync(new UriBuilder($"{SystemInformation.ApiAddress}/api/orders").Uri);

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<OrderRequestModel>>(content);

            }
        }
    }
}
