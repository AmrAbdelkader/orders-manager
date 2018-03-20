using System;
using System.Threading.Tasks;

namespace OrdersManager.Application.Orders
{
    public interface IOrderService
    {
        Task<OrderDto> Create(OrderDto ordertDto);
        Task<OrderDto> AddItem(OrderItemDto cartProductDto);
        OrderDto Remove(Guid customerId, Guid productId);
        Task<OrderDto> Get(Guid orderId);
    }
}
