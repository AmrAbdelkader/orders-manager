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
    [TestFixture]
    public class OrderControllerTests
    {
        Guid OrderId = new Guid("2143d854-0982-44b5-9c5d-acfaf3b7236a");
        Guid CustomerId = new Guid("c7daa440-096e-448b-ae45-d71268078225");

        Guid ItemId = new Guid("");

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
        [Category("ControllersTests")]
        public async Task Create_NewOrder_ReturnsCreatedOrder()
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
        public async Task Get_Controller()
        {
            //Arrange
            orderService.Setup(s => s.Get(OrderId)).ReturnsAsync(new OrderDto { Id = OrderId, CustomerId = CustomerId });
            OrdersController ordersController = new OrdersController(orderService.Object);

            //Act
            IActionResult actionResult = await ordersController.Get(OrderId);

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof(NotFoundResult), actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            List<string> messages = result.Value as List<string>;
            Assert.IsNotNull(messages);

            //Assert.AreEqual(HttpStatusCode.Accepted, negResult.StatusCode);
            //Assert.AreEqual("some updated data", negResult.Content);

        }

        //[Test]
        //[Category("ControllersTests")]
        //public async Task RemoveItem_ValidExistinItem_ReturnsOk()
        //{
        //    //Arrange
        //    OrderItemDto _orderDto = new OrderItemDto
        //    {
        //        ItemId = 
        //    };

        //    orderService.Setup(s => s.Remove(_orderDto)).ReturnsAsync(_orderDto);

        //    OrdersController ordersController = new OrdersController(orderService.Object);

        //    //Act
        //    var actionResult = await ordersController.Post(_orderDto);

        //    //Assert
        //    Assert.IsNotNull(actionResult);
        //    Assert.IsInstanceOf(typeof(CreatedResult), actionResult);
        //}
    }
}
