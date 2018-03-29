using Moq;
using NUnit.Framework;
using OrdersManager.Core.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrdersManager.Tests.DomainTests
{
    [TestFixture]
    public class OrderDomainTests
    {
        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");

        [SetUp]
        public void TestInit()
        {

        }

        [Test]
        public void Create_WithValidData_ReturnsConstructedOrder()
        {
            //Act
            Order actualOrder = Order.Create(CustomerId);

            //Assert
            Assert.IsTrue(actualOrder.Id != Guid.Empty);
        }

        [Test]
        public void AddItem_WithValidData_ReturnOrderWithAddedItem()
        {
            //Arrange
            Order order = Order.Create(OrderId);
            var newOrderItem = new OrderItem
            {
                ItemId = new Guid("970d5366-20b3-4f8d-87a6-973cba45c538"),
                Quantity = 2
            };

            //Act
            order.AddItem(newOrderItem);

            //Assert
            Assert.IsTrue(order.Items.Contains(newOrderItem));
        }

        [Test]
        public void RemoveItem_WithValidData_ReturnsOrderWithoutTheItem()
        {
            //Arrange
            Mock<Order> mockedOrder = new Mock<Order>();
            

            Order order = Order.Create(OrderId);
            var newOrderItem = new OrderItem
            {
                ItemId = new Guid("970d5366-20b3-4f8d-87a6-973cba45c538"),
                Quantity = 2
            };

            //Act
            order.AddItem(newOrderItem);

            //Assert
            Assert.IsTrue(order.Items.Contains(newOrderItem));
        }

    }
}
