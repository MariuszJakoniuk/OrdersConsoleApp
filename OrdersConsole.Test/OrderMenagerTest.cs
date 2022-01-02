using Moq;
using OrdersConsole.App.Abstract;
using OrdersConsole.App.Managers;
using OrdersConsole.Domain.Entity;
using System;
using Xunit;

namespace OrdersConsole.Test
{
    public class OrderMenagerTest
    {
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
            order.CreatedById = 1;
            order.CreatedDateTime = DateTime.Now;

            var mock = new Mock<IService<Order>>();
            _ = mock.Setup(s => s.GetItemById(id)).Returns(order);

            var manager = new OrderManager(mock.Object);

            //Act
            var returnerOrder = manager.GetItemByIdTest(order.Id);

            //Assert
            Assert.Equal(order, returnerOrder);
        }

        [Fact]
        public void UpdateItemStatusTest()
        {
            //Arrange
            int id = 1;
            Order order = new Order();
            order.Id = id;
            order.TypeId = 1;
            order.Name = "test";
            order.OrderDate = DateTime.Now;
            order.StatusId = 1;
            order.CreatedById = 1;
            order.CreatedDateTime = DateTime.Now;

            bool result = true;

            var mock = new Mock<IService<Order>>();
            mock.Setup(s => s.GetItemById(id)).Returns(order);
            mock.Setup(s => s.UpdateItem(order)).Returns(result);

            var manager = new OrderManager(mock.Object);

            //Act
            var returnerOrder = manager.UpdateItemStatus(order.Id, 2);

            //Assert
            Assert.Equal(result, returnerOrder);
        }

    }
}
