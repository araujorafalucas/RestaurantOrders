using RestaurantOrdersApi.RequestModels;
using RestaurantOrdersApi.ResponseModels;
using RestaurantOrdersApi.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace RestaurantOrdersApiTests
{
    public class OrderServiceTest : IClassFixture<MockTestDatabase>
    {
        private readonly MockTestDatabase MockTestDatabase = null;
        public OrderServiceTest(MockTestDatabase mockTestDatabase)
        {
            MockTestDatabase = mockTestDatabase;
        }

        [Theory]
        [InlineData("morning, 1, 2, 3", "eggs, toast, coffee")]
        [InlineData("morning, 2, 1, 3", "eggs, toast, coffee")]
        [InlineData("morning, 1, 2, 3, 4", "eggs, toast, coffee, error")]
        [InlineData("morning, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3)")]
        [InlineData("night, 1, 2, 3, 4", "steak, potato, wine, cake")]
        [InlineData("night, 1, 2, 2, 4", "steak, potato(x2), cake")]
        [InlineData("night, 1, 2, 3, 5", "steak, potato, wine, error")]
        [InlineData("night, 1, 1, 2, 3, 5", "steak, error")]
        public async void AddOrderReturnsOrderResponse(string input, string expectedOutput)
        {
            OrderService ordersService = new OrderService(new MealTimeService(MockTestDatabase.Context)
                                                         , new DishMealTimeService(MockTestDatabase.Context)
                                                         , new DishService(MockTestDatabase.Context)
                                                         , MockTestDatabase.Context);
            OrderRequest orderRequest = new OrderRequest();
            orderRequest.Input = input;
            var response = await ordersService.AddOrder(orderRequest);

            Assert.Equal(expectedOutput, response.Output, ignoreCase: true);

        }

        [Fact]
        public async void GetOrdersReturnsListOrderResponse()
        {
            AddOrderReturnsOrderResponse("night, 1, 1, 2, 3, 5", "steak, error");
            OrderService ordersService = new OrderService(new MealTimeService(MockTestDatabase.Context)
                                                          , new DishMealTimeService(MockTestDatabase.Context)
                                                          , new DishService(MockTestDatabase.Context)
                                                          , MockTestDatabase.Context);
            var response = await ordersService.GetOrders();

            Assert.IsType<List<OrderResponse>>(response);


        }
    }
}
