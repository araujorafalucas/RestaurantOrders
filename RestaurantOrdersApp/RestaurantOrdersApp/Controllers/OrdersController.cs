using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersApp.Models;

namespace RestaurantOrdersApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRequest OrderRequest = null;
        public OrdersController(IOrderRequest orderRequest)
        {
            OrderRequest = orderRequest;
        }
        public async Task<IActionResult> Index()
        {
            await OrderRequest.GetOrders();
            return View(OrderRequest);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(string input)
        {
            return Json(await OrderRequest.AddOrder(input));            
            
        }
    }
}
