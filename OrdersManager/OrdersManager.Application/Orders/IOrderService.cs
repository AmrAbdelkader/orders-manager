using System;

namespace OrdersManager.Application.Orders
{
    public interface IOrderService
    {
        OrderDto Create(OrderDto ordertDto);
        OrderDto Add(OrderItemDto cartProductDto);
        OrderDto Remove(Guid customerId, Guid productId);
        OrderDto Get(Guid customerId);
    }
}
