using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OrdersManager.Application.Mappings;
using OrdersManager.Application.Orders;
using OrdersManager.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Tests.ControllersTests
{
    [TestFixture, Category("ControllerTests")]
    public class OrderControllerTests
    {
        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");
        Guid ItemId = new Guid("970d5366-20b3-4f8d-87a6-973cba45c538");

        Mock<IOrderService> orderService;

        [SetUp]
        public void TestInit()
        {
            orderService = new Mock<IOrderService>();

            var mappings = new MapperConfigurationExpression();
            mappings.AddProfile<ApplicationMapperProfile>();
            AutoMapper.Mapper.Initialize(mappings);
        }

        [Test]
        public async Task Create_NewOrder_ReturnsHttpCreated()
        {
            //Arrange
            OrderDto _orderDto = new OrderDto
            {
                Id = OrderId,
                CustomerId = CustomerId
            };
            orderService.Setup(s => s.Create(_orderDto)).ReturnsAsync(_orderDto);
            OrdersController ordersController = new OrdersController(orderService.Object);
            //Act
            var actionResult = await ordersController.Post(_orderDto);
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof(CreatedResult), actionResult);
        }

        [Test]
        public async Task Get_ExistingOrder_ReturnsHttpOkWithOrder()
        {
            //Arrange
            orderService.Setup(s => s.Get(OrderId)).ReturnsAsync(new OrderDto { Id = OrderId, CustomerId = CustomerId });
            OrdersController ordersController = new OrdersController(orderService.Object);

            //Act
            IActionResult actionResult = await ordersController.Get(OrderId);

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            OrderDto orderData = result.Value as OrderDto;
            Assert.IsNotNull(orderData);
        }

        [Test]
        public async Task RemoveItem_ValidExistinItem_ReturnsOk()
        {
            //Arrange
            orderService.Setup(s => s.RemoveItem(OrderId, ItemId)).
                ReturnsAsync(new OrderDto { Id = OrderId });

            OrdersController ordersController = new OrdersController(orderService.Object);

            //Act
            var actionResult = await ordersController.Delete(OrderId, ItemId);

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof(OkObjectResult), actionResult);
            OkObjectResult result = actionResult as OkObjectResult;
            OrderDto orderData = result.Value as OrderDto;
            Assert.IsNotNull(orderData);
            Assert.IsNull(orderData.Items);
        }

        [Test]
        public async Task ClearOrder_WithValidOrder_ReturnsNoContent()
        {
            //Arrange
            orderService.Setup(s => s.Clear(OrderId)).Returns(Task.CompletedTask);
            OrdersController ordersController = new OrdersController(orderService.Object);
            //Act
            var actionResult = await ordersController.Patch(OrderId);
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof(NoContentResult), actionResult);
        }
    }
}
