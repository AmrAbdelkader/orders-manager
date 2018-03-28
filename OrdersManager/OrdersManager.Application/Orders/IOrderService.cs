using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManager.Application.Orders
{
    /// <summary>
    /// IOrderService inteface defines Order service operations
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates the specified order dto.
        /// </summary>
        /// <param name="OrdertDto">The order dto.</param>
        /// <returns></returns>
        Task<OrderDto> Create(OrderDto OrderDto);
        
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <param name="OrderItemDto">The order item dto.</param>
        /// <returns></returns>
        Task<OrderDto> AddItem(Guid OrderId, OrderItemDto OrderItemDto);
        
        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <param name="ItemId">The item identifier.</param>
        /// <returns></returns>
        Task<OrderDto> RemoveItem(Guid OrderId, Guid ItemId);
        
        /// <summary>
        /// Gets the specified order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        Task<OrderDto> Get(Guid OrderId);
        
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OrderDto>> Get();
        
        /// <summary>
        /// Clears the specified order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        Task Clear(Guid OrderId);
        
        /// <summary>
        /// Deletes the specified order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        Task Delete(Guid OrderId);
    }
}
