using AutoMapper.Configuration;
using Moq;
using NUnit.Framework;
using OrdersManager.Application.Exceptions;
using OrdersManager.Application.Mappings;
using OrdersManager.Application.Orders;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Specification;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Tests.ApplicationTests
{
    [TestFixture, Category("ApplicationTests")]
    public class OrdersServiceTests
    {
        Mock<IUnitOfWork> _uow;
        Mock<IRepository<User>> _UserRepo;
        Mock<IRepository<Order>> _OrderRepo;
        Mock<IRepository<Item>> _ItemRepo;
        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");
        Guid ItemId = new Guid("970d5366-20b3-4f8d-87a6-973cba45c538");

        [SetUp]
        public void TestInit()
        {
            _uow = new Mock<IUnitOfWork>();
            _UserRepo = new Mock<IRepository<User>>();
            _OrderRepo = new Mock<IRepository<Order>>();
            _ItemRepo = new Mock<IRepository<Item>>();

            var mappings = new MapperConfigurationExpression();
            mappings.AddProfile<ApplicationMapperProfile>();
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(mappings);
        }

        [Test]
        public async Task Create_NewValidOrder_ReturnsCreatedOrder()
        {
            //Arrange
            Mock<User> mockedUser = new Mock<User>();
            mockedUser.SetupGet(u => u.Id).Returns(CustomerId);

            _UserRepo.Setup(u => u.FindById(CustomerId)).ReturnsAsync(mockedUser.Object);

            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);

            //Act
            var actualOrder = await orderService.Create(new OrderDto { CustomerId = CustomerId });

            //Assert
            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public void Create_NewOrderWithInvalidUser_ThrowsServiceException()
        {
            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);

            Assert.ThrowsAsync<ServiceException>(async () =>
            {
                await orderService.Create(new OrderDto { CustomerId = Guid.Empty });
            });
        }

        [Test]
        public async Task Get_ExistingOrder_ReturnsOrder()
        {
            //Arrange
            Mock<Order> mockedOrder = new Mock<Order>();
            mockedOrder.CallBase = true;
            mockedOrder.SetupGet(u => u.Id).Returns(OrderId);

            _OrderRepo.Setup(o => o.FindById(OrderId)).ReturnsAsync(mockedOrder.Object);

            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);

            //Act
            var order = await orderService.Get(OrderId);

            //Assert
            Assert.IsNotNull(order);
        }

        [Test]
        public void Get_NonExistingOrder_ThrowsServiceException()
        {
            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);
            Assert.ThrowsAsync<ServiceException>(async () =>
            {
                await orderService.Get(OrderId);
            });
        }

        [Test]
        public async Task Add_NewOrderItem_ReturnOrderWithItemsCollection()
        {
            //Arrange
            SetupOrderWithItem();

            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);

            //Act
            var updatedOrder = await orderService.AddItem(OrderId, new OrderItemDto
            {
                ItemId = ItemId,
                Quantity = 5
            });

            //Assert
            _uow.Verify(u => u.Commit(), Times.Once);
        }

        [Test]
        public async Task UpdateItemQuantity_WithExistingItem_ReturnOrderWithItemsCollection()
        {
            //Arrange
            SetupOrderWithItem();

            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);

            var ItemToAdd = new OrderItemDto
            {
                ItemId = ItemId,
                Quantity = 2
            };
            //Act
            await orderService.AddItem(OrderId, ItemToAdd);

            ItemToAdd.Quantity = 5;

            var updatedOrder = await orderService.AddItem(OrderId, ItemToAdd);

            //Assert
            Assert.AreEqual(100, updatedOrder.Total);
        }

        [Test]
        public async Task RemoveItem_WithValidOrder_ReturnsOrderWithRemovedItem()
        {
            //Arrange
            SetupOrderWithItem();
            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);
            var ItemToAdd = new OrderItemDto
            {
                ItemId = ItemId,
                Quantity = 2
            };
            await orderService.AddItem(OrderId, ItemToAdd);
            //Act
            var updatedOrder = await orderService.RemoveItem(OrderId, ItemId);

            //Assert
            Assert.IsTrue(updatedOrder.Items.Count == 0);
            Assert.AreEqual(0, updatedOrder.Total);
        }

        private void SetupOrderWithItem()
        {
            Mock<Item> mockedItem = new Mock<Item>();
            mockedItem.SetupGet(u => u.Id).Returns(ItemId);
            mockedItem.SetupGet(u => u.Price).Returns(20);

            Mock<Order> mockedOrder = new Mock<Order>();
            mockedOrder.CallBase = true;
            mockedOrder.SetupGet(o => o.Id).Returns(OrderId);

            _OrderRepo.Setup(o => o.FindOne(It.IsAny<ISpecification<Order>>()))
                .ReturnsAsync(mockedOrder.Object);

            _ItemRepo.Setup(o => o.FindById(ItemId)).ReturnsAsync(mockedItem.Object);
        }

    }
}
