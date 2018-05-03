using Moq;
using NUnit.Framework;
using OrdersManager.Core.Orders;
using OrdersManager.Infrastructure;
using OrdersManager.Infrastructure.Stubs;
using System;
using System.Threading.Tasks;

namespace OrdersManager.Tests.RepositoryTests
{
    [TestFixture, Category("RepositoryTests")]
    public class OrderRepositoryTests
    {

        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");
        MemoryRepository<Order> _orderRepo;
        StubDataOrderRepository OrderStub;

        [SetUp]
        public void TestInit()
        {
            _orderRepo = new MemoryRepository<Order>();
            OrderStub = new StubDataOrderRepository(_orderRepo);
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
        public async Task GetOrder_WithValidOrderId_ReturnsSavedOrder()
        {
            //Act
            var ActualOrder = await OrderStub.FindById(OrderId);
            
            //Assert
            Assert.AreEqual(OrderId, ActualOrder.Id);
        }

        [Test]
        public async Task DeleteOrder_WithValidOrderId_DeletesSpecifiedOrder()
        {
            //Arrange
            var OrderToDelete = await OrderStub.FindById(OrderId);
            
            //Act
            Task removedTask = OrderStub.Remove(OrderToDelete);

            //Assert
            Assert.IsTrue(removedTask.IsCompleted);
        }

    }
}
