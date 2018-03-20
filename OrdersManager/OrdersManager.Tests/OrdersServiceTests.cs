using Moq;
using NUnit.Framework;
using OrdersManager.Application.Orders;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Tests
{
    [TestFixture]
    public class OrdersServiceTests
    {
        Mock<IUnitOfWork> _uow;
        Mock<IRepository<User>> _UserRepo;
        Mock<IRepository<Order>> _OrderRepo;
        Mock<IRepository<Item>> _ItemRepo;

        [SetUp]
        public void TestInit()
        {
            var _uow = new Mock<IUnitOfWork>();
            var _UserRepo = new Mock<IRepository<User>>();
            var _OrderRepo = new Mock<IRepository<Order>>();
            var _ItemRepo = new Mock<IRepository<Item>>();
        }


        [Test]
        public void Get_ExistingOrder_ReturnsOrder()
        {
            //arrange
            var _OrderService = new Mock<IOrderService>();

            var order = _OrderService.Object.Get(Guid.NewGuid());

            Assert.IsNotNull(order);
        }
    }
}
