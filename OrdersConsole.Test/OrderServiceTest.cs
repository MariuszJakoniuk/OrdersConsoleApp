using Moq;
using OrdersConsole.App.Abstract;
using OrdersConsole.App.Concrete;
using OrdersConsole.Domain.Entity;
using System;
using Xunit;

namespace Orders.Test
{
    public class OrderServiceTest
    {
        [Fact]
        public void AddItemTest()
        {
            //Arrange
            int id = 1;
            Order order = new Order();
            order.Id = id;
            order.TypeId = 1;
            order.Name = "test";
            order.OrderDate = DateTime.Now;
            order.StatusId = 1;
            order.CreatedById = "me";
            order.CreatedDateTime = DateTime.Now;
          
            OrderService orderService = new OrderService();

            //Act
            int testid = orderService.AddItem(order);
            //Assert
           Assert.Equal(id, testid);
        }

        [Fact]
        public void GetItemByIdTest()
        {
            //Arrange
            int id = 1;
            Order order = new Order();
            order.Id = id;
            order.TypeId = 1;
            order.Name = "test";
            order.OrderDate = DateTime.Now;
            order.StatusId = 1;
            order.CreatedById = "me";
            order.CreatedDateTime = DateTime.Now;

            var mock = new Mock<IService<Order>>();
            _ = mock.Setup(s => s.GetItemById(id)).Returns(order);

            var orderService = new OrderService();

            //Act
            orderService.AddItem(order);
            var returnerOrder = orderService.GetItemById(order.Id);

            //Assert
            Assert.Equal(order, returnerOrder);
        }
    }
}