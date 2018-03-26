using System;
using System.Threading.Tasks;

namespace OrdersManager.Application.Orders
{
    public interface IOrderService
    {
        Task<OrderDto> Create(OrderDto OrdertDto);
        Task<OrderDto> AddItem(Guid OrderId, OrderItemDto OrderItemDto);
        Task<OrderDto> RemoveItem(Guid OrderId, Guid ItemId);
        Task<OrderDto> Get(Guid OrderId);
        Task Clear(Guid OrderId);
    }
}
