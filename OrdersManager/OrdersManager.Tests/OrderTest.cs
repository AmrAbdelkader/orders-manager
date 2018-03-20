using Moq;
using NUnit.Framework;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Tests
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void Create_NewEmptyOrder_ReturnsConstructedOrder()
        {
            //arrange
            Mock<User> user = new Mock<User>();
            user.SetupGet(u => u.Id).Returns(new Guid("c7daa440-096e-448b-ae45-d71268078225"));
            
            //act
            var createdOrder = Order.Create(user.Object);
            
            //assert
            Assert.AreNotSame(createdOrder.Id, Guid.Empty);
        }
        
    }
}
