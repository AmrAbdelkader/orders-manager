using AutoMapper;
using OrdersManager.Application.Exceptions;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

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
        
        public OrderDto Create(OrderDto orderDto)
        {
            User customer = userRepository.FindById(orderDto.CustomerId);
            if (customer == null)
                throw new OrdersServiceException($"Customer with Id {orderDto.CustomerId} does not exist.");

            Order newOrder = Order.Create(customer);
            orderRepository.Add(newOrder);
            return orderDto;
        }

        public OrderDto Add(OrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }

        public OrderDto Get(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public OrderDto Remove(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
