using Microsoft.EntityFrameworkCore;
using RestaurantOrdersApi.Context;
using RestaurantOrdersApi.Entities;
using RestaurantOrdersApi.RequestModels;
using RestaurantOrdersApi.ResponseModels;
using RestaurantOrdersApi.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrdersApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMealTimeService MealTimeService = null;
        private readonly IDishMealTimeService DishMealTimeService = null;
        private readonly IDishService DishService = null;
        private readonly AppDbContext Context = null;
        public OrderService(IMealTimeService mealTimeService
                            , IDishMealTimeService dishMealTimeService
                            , IDishService dishService
                            , AppDbContext context)
        {
            MealTimeService = mealTimeService;
            DishMealTimeService = dishMealTimeService;
            DishService = dishService;
            Context = context;
        }
        public async Task<OrderResponse> AddOrder(OrderRequest orderRequest)
        {
            Order order = await ValidateAndCreateOrder(orderRequest);

            Context.Orders.Add(order);
            Context.SaveChanges();
            return CreateResponse(order);
        }

        private async Task<Order> ValidateAndCreateOrder(OrderRequest orderRequest)
        {
            Order order = new Order();
            order.OrderedDate = DateTime.Now;
            order.RequestedOrder = orderRequest.Input;
            string result = string.Empty;
            var infoInputedOrder = orderRequest.Input.Split(',').ToList();

            if (infoInputedOrder.Count < 2)
            {
                order.HasInputError = true;
            }
            else
            {
                MealTime mealTime = await MealTimeService.GetActiveMealTimeByDescription(infoInputedOrder[0]);

                if (mealTime == null)
                {
                    order.HasInputError = true;
                }
                else
                {
                    order.MealTimeId = mealTime.MealTimeId;
                    bool isValidInput = true;
                    int dishesAmount = 0;
                    order.OrderItems = new List<OrderItem>();

                    var agrupedDishTypes = infoInputedOrder.Skip(1).GroupBy(types => types).Select(x => new { TypeId = x.Key, Amount = x.Count() });

                    foreach (var inputedDishType in agrupedDishTypes)
                    {
                        if (order.HasInputError)
                        {
                            break;
                        }

                        var dishes = await DishService.GetActivesDishesByDishTypeIdMealTimeId(Convert.ToInt32(inputedDishType.TypeId), mealTime.MealTimeId);

                        if (dishes == null || dishes.Count == 0)
                        {
                            order.HasInputError = true;
                            break;
                        }

                        foreach (var dish in dishes)
                        {
                            var dishMealTime = await DishMealTimeService.GetDishMealTimeById(dish.DishId, mealTime.MealTimeId);

                            if (dishMealTime != null)
                            {
                                isValidInput = true;
                                dishesAmount = 0;

                                if (dishMealTime.MaxAllowed < inputedDishType.Amount
                                    && dishMealTime.MaxAllowed > 0)
                                {
                                    isValidInput = false;
                                    dishesAmount = dishMealTime.MaxAllowed;
                                }
                                else
                                {
                                    dishesAmount = inputedDishType.Amount;
                                }

                                order.OrderItems.Add(new OrderItem()
                                {
                                    DishId = dish.DishId,
                                    AmountOrdered = dishesAmount
                                });

                                if (!isValidInput)
                                {
                                    order.HasInputError = true;
                                    break;
                                }

                            }
                        }

                    }
                }
            }

            return await Task.FromResult(order);
        }

        private OrderResponse CreateResponse(Order order)
        {
            var items = (from itemsQuery in Context.OrderItems.Include(x => x.Dish)
                         join dishesQuery in Context.Dishes.Include(x => x.DishType)
                           on itemsQuery.DishId equals dishesQuery.DishId
                         join types in Context.DishTypes
                           on dishesQuery.DishTypeId equals types.DishTypeId
                         orderby types.Sequence
                         where itemsQuery.OrderId == order.OrderId
                         select itemsQuery).ToList();

            List<string> outputList = new List<string>();
            //order.OrderItems = order.OrderItems.OrderBy(x => x.Dish.DishType.Sequence).ToList();

            foreach (var item in items)
            {
                if (item.AmountOrdered > 1)
                {
                    outputList.Add($"{ item.Dish.Description }(x{ item.AmountOrdered })");
                }
                else
                {
                    outputList.Add(item.Dish.Description);
                }
            }

            if (order.HasInputError)
            {
                outputList.Add("error");
            }

            OrderResponse orderResponse = new OrderResponse();
            orderResponse.Input = order.RequestedOrder;
            orderResponse.Output = string.Join(", ", outputList);
            return orderResponse;
        }
        public async Task<List<OrderResponse>> GetOrders()
        {

            var orders = await Context.Orders.ToListAsync();
            List<OrderResponse> response = new List<OrderResponse>();

            foreach (var order in orders)
            {
                response.Add(CreateResponse(order));
            }
            return response;
        }

        public async Task<OrderResponse> GetOrderById(int id)
        {
            var order = await Context.Orders.FirstOrDefaultAsync(order => order.OrderId == id);

            if (order == null)
                return null;

            return CreateResponse(order);

        }
    }
}
