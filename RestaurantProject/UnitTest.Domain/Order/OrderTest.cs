using Builders.Order;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;

namespace UnitTest.Domain.Order
{
    public class OrderTest
    {
        [Fact]
        public void Check_Order_Total_Price()
        {
            //Arrange
            var dataBaseBuilder = new DatabaseBuilder();
            var dbConnection = dataBaseBuilder.GetDbContext();
            OrderBuilder orderBuilder = new OrderBuilder()
            {
                Id = 1,
                OrderCode = "123order",
                OrderDate = DateTime.Now,
                orderStatus = OrderBuilder.OrderStatus.Processing,
                OrderItems = new List<OrderItemBuilder>
                { new OrderItemBuilder() { Id = 1, ProductName = "Test1", UnitPrice = 1000, Units = 5 } }
            };


            //Acat
            var orderResult = orderBuilder.TotalPrice();

            //Assert
            Assert.Equal(5000, orderResult);
            Assert.IsType<int>(orderResult);
        }
    }
}
