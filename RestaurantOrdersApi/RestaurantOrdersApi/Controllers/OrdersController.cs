using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersApi.RequestModels;
using RestaurantOrdersApi.ResponseModels;
using RestaurantOrdersApi.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService OrderItemService = null;
        public OrdersController(IOrderService orderItemService)
        {
            OrderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> AddOrder([FromBody] OrderRequest orderRequest)
        {
            return Ok(await OrderItemService.AddOrder(orderRequest));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
        {
            return Ok(await OrderItemService.GetOrders());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
        {
            var orderResponse = await OrderItemService.GetOrderById(id);
            if (orderResponse == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderResponse);
            }
        }
    }
}
