using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Application.Exceptions;
using OrdersManager.Application.Orders;
using OrdersManager.Web.Filters;

namespace OrdersManager.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var order = await _orderService.Get(id);
                return Ok(order);
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }

        // POST: api/Orders
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> Post([FromBody]OrderDto orderDto)
        {
            try
            {
                var createdOrder = await _orderService.Create(orderDto);
                return Created($"api/Orders/{createdOrder.Id}", createdOrder);
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }

        // PUT: api/Orders/5
        [HttpPut("{orderId}")]
        [ValidateModel]
        public async Task<ActionResult> Put(Guid orderId, [FromBody]OrderItemDto orderItemDto)
        {
            try
            {
                var updatedOrder = await _orderService.AddItem(orderId, orderItemDto);
                return Ok(updatedOrder);
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
