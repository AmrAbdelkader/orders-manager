using AutoMapper;
using OrdersManager.Application.Exceptions;
using OrdersManager.Core.Domain;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Application.Orders
{
    public class OrderService : IOrderService
    {
        IRepository<User> userRepository;
        IRepository<Item> itemRepository;
        IRepository<Order> orderRepository;
        IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork, IRepository<User> userRepository,
            IRepository<Item> itemRepository, IRepository<Order> orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
        }
        
        public virtual async Task<OrderDto> Create(OrderDto orderDto)
        {
            User customer = await userRepository.FindById(orderDto.CustomerId);
            if (customer == null)
                throw new ServiceException($"Customer with Id {orderDto.CustomerId} does not exist.");

            Order newOrder = Order.Create(customer.Id);
            await orderRepository.Add(newOrder);
            return Mapper.Map<OrderDto>(newOrder);
        }

        public virtual async Task<OrderDto> AddItem(Guid OrderId, OrderItemDto orderItemDto)
        {
            OrderDto orderDto = null;
            
            Order order = await orderRepository.FindOne(new OrderSpec(OrderId));
            if (order == null)
                throw new ServiceException($"Order with Id {OrderId} does not exist.");

            Item item = await itemRepository.FindById(orderItemDto.ItemId);
            if(item == null)
                throw new ServiceException($"Item with Id {orderItemDto.ItemId} does not exist.");
            try
            {
                order.AddItem(OrderItem.Create(order, item, orderItemDto.Quantity));
            }
            catch (DomainException exc)
            {
                throw new ServiceException(exc.Message);
            }

            orderDto = Mapper.Map<Order, OrderDto>(order);
            unitOfWork.Commit();
            return orderDto;
        }

        public virtual async Task<OrderDto> Get(Guid OrderId)
        {
            Order order = await orderRepository.FindById(OrderId);
            if (order == null)
                throw new ServiceException($"Order with Id {OrderId} does not exist.");

            return Mapper.Map<OrderDto>(order);
        }

        public virtual OrderDto Remove(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDto> RemoveItem(Guid orderId, OrderItemDto orderItemDto)
        {
            OrderDto orderDto = null;

            Order order = await orderRepository.FindOne(new OrderSpec(orderId));
            if (order == null)
                throw new ServiceException($"Order with Id {orderId} does not exist.");

            Item item = await itemRepository.FindById(orderItemDto.ItemId);
            if (item == null)
                throw new ServiceException($"Item with Id {orderItemDto.ItemId} does not exist.");
            try
            {
                order.RemoveItem(Mapper.Map<OrderItem>(orderItemDto));
            }
            catch (DomainException exc)
            {
                throw new ServiceException(exc.Message);
            }

            orderDto = Mapper.Map<Order, OrderDto>(order);
            unitOfWork.Commit();
            return orderDto;
        }
    }
}
