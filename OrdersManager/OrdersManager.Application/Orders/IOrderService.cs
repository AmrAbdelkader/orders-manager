using System;
using System.Threading.Tasks;

namespace OrdersManager.Application.Orders
{
    public interface IOrderService
    {
        Task<OrderDto> Create(OrderDto ordertDto);
        Task<OrderDto> AddItem(Guid orderId, OrderItemDto orderItemDto);
        Task<OrderDto> RemoveItem(Guid orderId, OrderItemDto orderItemDto);
        Task<OrderDto> Get(Guid orderId);
    }
}
