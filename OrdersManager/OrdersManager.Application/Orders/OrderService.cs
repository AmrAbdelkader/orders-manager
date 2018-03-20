using AutoMapper;
using OrdersManager.Application.Exceptions;
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
        
        public async Task<OrderDto> Create(OrderDto orderDto)
        {
            User customer = await userRepository.FindById(orderDto.CustomerId);
            if (customer == null)
                throw new OrdersServiceException($"Customer with Id {orderDto.CustomerId} does not exist.");

            Order newOrder = Order.Create(customer);
            orderRepository.Add(newOrder);
            return Mapper.Map<OrderDto>(newOrder);
        }

        public async Task<OrderDto> AddItem(OrderItemDto orderItemDto)
        {
            OrderDto orderDto = null;
                
            User customer = await userRepository.FindById(orderItemDto.CustomerId);
            if (customer == null)
                throw new OrdersServiceException($"Customer with Id {orderItemDto.CustomerId} does not exist.");

            Order order = orderRepository.FindOne(new UserOrderSpec(orderItemDto.CustomerId));
            //if (order == null)
            //    throw new OrdersServiceException($"Order with Id {orderItemDto.OrderId} does not exist.");

            Item item = await itemRepository.FindById(orderItemDto.ItemId);
            if(item == null)
                throw new OrdersServiceException($"Item with Id {orderItemDto.ItemId} does not exist.");
            
            order.AddItem(OrderItem.Create(customer, order, item, orderItemDto.Quantity));

            orderDto = Mapper.Map<Order, OrderDto>(order);
            unitOfWork.Commit();
            return orderDto;
        }

        public async Task<OrderDto> Get(Guid OrderId)
        {
            Order order = await orderRepository.FindById(OrderId);
            if (order == null)
                throw new OrdersServiceException($"Order with Id {OrderId} does not exist.");

            return Mapper.Map<OrderDto>(order);
        }

        public OrderDto Remove(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
