using Moq;
using NUnit.Framework;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Orders;
using OrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Tests.RepositoryTests
{
    [TestFixture]
    public class OrderRepositoryTests
    {

        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");
        IDomainEventRepository<Order> _orderRepo;


        [SetUp]
        public void TestInit()
        {
            _orderRepo = new MemoryRepository<Order>();
        }


        [Test]
        public async Task Create_NewOrder_SaveNewOrder()
        {
            Mock<Order> mockOrder = new Mock<Order>();
            mockOrder.SetupGet(x => x.Id).Returns(OrderId);
            mockOrder.SetupGet(x => x.CustomerId).Returns(CustomerId);

            await _orderRepo.Add(mockOrder.Object);

            var actualOrder = await _orderRepo.FindById(mockOrder.Object.Id);

            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public void Get_Order_Repo()
        {

            //Act
            var order = _orderRepo.FindById(OrderId);

            //Assert
            Assert.IsNotNull(order);

        }

    }
}
