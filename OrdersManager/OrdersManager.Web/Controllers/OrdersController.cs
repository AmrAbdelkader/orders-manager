using Microsoft.AspNetCore.Mvc;
using OrdersManager.Application.Exceptions;
using OrdersManager.Application.Orders;
using OrdersManager.Web.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var orderList = await _orderService.Get();
                return Ok(orderList);
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
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
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
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
        [HttpPut("{orderId}/items")]
        [ValidateModel]
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
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

        [HttpDelete("{orderId}/items/{itemId}")]
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult> Delete(Guid orderId, Guid itemId)
        {
            try
            {
                var updatedOrder = await _orderService.RemoveItem(orderId, itemId);
                return Ok(updatedOrder);
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }

        [HttpPatch("{orderId}/items")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult> Patch(Guid orderId)
        {
            try
            {
                await _orderService.Clear(orderId);
                return NoContent();
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{orderId}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult> Delete(Guid orderId)
        {
            try
            {
                await _orderService.Delete(orderId);
                return NoContent();
            }
            catch (ServiceException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
