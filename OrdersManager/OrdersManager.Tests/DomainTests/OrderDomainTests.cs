using Moq;
using NUnit.Framework;
using OrdersManager.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Tests.DomainTests
{
    [TestFixture]
    public class OrderDomainTests
    {

        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");

        [SetUp]
        public void TestInit()
        {

        }

        public void Create_WithValidData_ReturnsConstructedOrder()
        {
            //Arrange
            Mock<Order> expected = new Mock<Order>();
            expected.SetupGet(x => x.CustomerId).Returns(CustomerId);

            //Act
            Order actualOrder = Order.Create(CustomerId);

            //Assert
            Assert.IsTrue(actualOrder.Id != Guid.Empty);
        }
        
        [Test]
        public void Get_order_domain()
        {
            Order order = new Order();

        }
    }
}
