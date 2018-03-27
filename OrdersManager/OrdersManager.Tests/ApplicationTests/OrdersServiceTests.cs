using AutoMapper.Configuration;
using Moq;
using NUnit.Framework;
using OrdersManager.Application.Exceptions;
using OrdersManager.Application.Mappings;
using OrdersManager.Application.Orders;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Tests.ApplicationTests
{
    [TestFixture]
    public class OrdersServiceTests
    {
        Mock<IUnitOfWork> _uow;
        Mock<IDomainEventRepository<User>> _UserRepo;
        Mock<IDomainEventRepository<Order>> _OrderRepo;
        Mock<IDomainEventRepository<Item>> _ItemRepo;
        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");

        [SetUp]
        public void TestInit()
        {
            _uow = new Mock<IUnitOfWork>();
            _UserRepo = new Mock<IDomainEventRepository<User>>();
            _OrderRepo = new Mock<IDomainEventRepository<Order>>();
            _ItemRepo = new Mock<IDomainEventRepository<Item>>();

            var mappings = new MapperConfigurationExpression();
            mappings.AddProfile<ApplicationMapperProfile>();
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
        public void Create_NewOrderWithInvalidUser_ReturnsCreatedOrder()
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
        public async Task get_invalid_contact_returns_null()
        {
            //repoMock.Expect(x => x.GetContact(Arg.Is<int>(contactId))).Return(null);
            _OrderRepo.Setup(o => o.FindById(OrderId).Result).Returns(Order.Create(OrderId, CustomerId));
            var orderService = new OrderService(_uow.Object,
                _UserRepo.Object,
                _ItemRepo.Object,
                _OrderRepo.Object);

            await orderService.Get(OrderId);

            //TestUnitOfWork.ContactsRepository = repoMock;

            //var contact = ServiceFactory.ContactsService.GetById(contactId);

            //Assert.IsNull(contact);
        }



        [Test]
        public void Add_NewOrderItem_ReturnOrderWithItemsCollection()
        {
            //Arrange


            //Act


            //Assert
        }

    }
}
