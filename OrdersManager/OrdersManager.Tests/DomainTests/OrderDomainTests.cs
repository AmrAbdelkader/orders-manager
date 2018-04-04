using Moq;
using NUnit.Framework;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrdersManager.Tests.DomainTests
{
    [TestFixture, Category("DomainTests")]
    public class OrderDomainTests
    {
        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");
        Guid ItemId = new Guid("970d5366-20b3-4f8d-87a6-973cba45c538");

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
        public void AddItem_WithValidItemData_ReturnsConstructedOrder()
        {
            //Arrange
            var newOrder = Order.Create(CustomerId);
            
            Mock<Item> MockedItem = new Mock<Item>();
            MockedItem.SetupGet(i => i.Price).Returns(20);
            var newItem = OrderItem.Create(newOrder, MockedItem.Object, 3);
            
            //Act
            newOrder.AddItem(newItem);

            //Assert
            Assert.IsTrue(newOrder.Items[0].ItemId == MockedItem.Object.Id);
            var expectedTotal = 60;
            Assert.AreEqual(expectedTotal, newOrder.Total);
        }

        [Test]
        public void UpdateOrder_ChangeExistingItemQuantity_ReturnsUpdatedOrder()
        {
            //Arrange
            Mock<Item> MockedItem = new Mock<Item>();
            MockedItem.SetupGet(i => i.Id).Returns(ItemId);
            MockedItem.SetupGet(i => i.Price).Returns(20);
            
            var _Order = Order.Create(CustomerId);
            var _OrderItem = OrderItem.Create(_Order, MockedItem.Object, 2);
            _Order.AddItem(_OrderItem);
            
            //Act
            _OrderItem.Quantity = 5;
            _Order.AddItem(_OrderItem);

            //Assert
            Assert.AreEqual(_Order.Items.Count, 1);
            Assert.IsTrue(_Order.Items[0].Quantity == 5);
            Assert.AreEqual(100, _Order.Total);
        }

        [Test]
        public void RemoveItem_WithValidItemData_ReturnsUpdatedOrder()
        {
            //Arrange
            Mock<Item> MockedItem = new Mock<Item>();
            MockedItem.SetupGet(i => i.Id).Returns(ItemId);

            var _Order = Order.Create(CustomerId);
            var _OrderItem = OrderItem.Create(_Order, MockedItem.Object, 2);
            _Order.AddItem(_OrderItem);

            //Act
            _Order.RemoveItem(ItemId);

            //Assert
            Assert.AreEqual(_Order.Items.Count, 0);
            Assert.AreEqual(0, _Order.Total);
        }
        
    }
}
