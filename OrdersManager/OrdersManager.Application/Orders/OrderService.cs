using AutoMapper;
using OrdersManager.Application.Exceptions;
using OrdersManager.Core.Domain;
using OrdersManager.Core.Interfaces;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using OrdersManager.Core.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManager.Application.Orders
{
    /// <summary>
    /// OrderService implements IOrderService interface
    /// </summary>
    /// <seealso cref="OrdersManager.Application.Orders.IOrderService" />
    public class OrderService : IOrderService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        IRepository<User> userRepository;
        /// <summary>
        /// The item repository
        /// </summary>
        IRepository<Item> itemRepository;
        /// <summary>
        /// The order repository
        /// </summary>
        IRepository<Order> orderRepository;
        /// <summary>
        /// The unit of work
        /// </summary>
        IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="itemRepository">The item repository.</param>
        /// <param name="orderRepository">The order repository.</param>
        public OrderService(IUnitOfWork unitOfWork, IRepository<User> userRepository,
            IRepository<Item> itemRepository, IRepository<Order> orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// Creates the specified order dto.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        /// <returns></returns>
        /// <exception cref="OrdersManager.Application.Exceptions.ServiceException"></exception>
        public virtual async Task<OrderDto> Create(OrderDto orderDto)
        {
            User customer = await userRepository.FindById(orderDto.CustomerId);
            if (customer == null)
                throw new ServiceException($"Customer with Id {orderDto.CustomerId} does not exist.");

            Order newOrder = Order.Create(customer.Id);
            await orderRepository.Add(newOrder);
            return Mapper.Map<OrderDto>(newOrder);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <param name="orderItemDto">The order item dto.</param>
        /// <returns></returns>
        /// <exception cref="OrdersManager.Application.Exceptions.ServiceException">
        /// </exception>
        public virtual async Task<OrderDto> AddItem(Guid OrderId, OrderItemDto orderItemDto)
        {
            OrderDto orderDto = null;
            
            Order order = await orderRepository.FindOne(new OrderSpec(OrderId));

            if (order == null)
                throw new ServiceException($"Order with Id {OrderId} does not exist.");

            Item item = await itemRepository.FindById(orderItemDto.ItemId);

            if (item == null)
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

        /// <summary>
        /// Gets the specified order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="OrdersManager.Application.Exceptions.ServiceException"></exception>
        public virtual async Task<OrderDto> Get(Guid OrderId)
        {
            Order order = await orderRepository.FindById(OrderId);
            if (order == null)
                throw new ServiceException($"Order with Id {OrderId} does not exist.");

            return Mapper.Map<OrderDto>(order);
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<OrderDto>> Get()
        {
            var ordersList = await orderRepository.Find(new OrdersListSpec());
            return Mapper.Map<IEnumerable<OrderDto>>(ordersList);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="ItemId">The item identifier.</param>
        /// <returns></returns>
        /// <exception cref="OrdersManager.Application.Exceptions.ServiceException">
        /// </exception>
        public virtual async Task<OrderDto> RemoveItem(Guid orderId, Guid ItemId)
        {
            OrderDto orderDto = null;

            Order order = await orderRepository.FindOne(new OrderSpec(orderId));
            if (order == null)
                throw new ServiceException($"Order with Id {orderId} does not exist.");

            Item item = await itemRepository.FindById(ItemId);
            if (item == null)
                throw new ServiceException($"Item with Id {ItemId} does not exist.");

            try
            {
                order.RemoveItem(ItemId);
            }
            catch (DomainException exc)
            {
                throw new ServiceException(exc.Message);
            }

            orderDto = Mapper.Map<Order, OrderDto>(order);
            unitOfWork.Commit();
            return orderDto;
        }

        /// <summary>
        /// Clears the specified order items.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="OrdersManager.Application.Exceptions.ServiceException"></exception>
        public virtual async Task Clear(Guid OrderId)
        {
            Order order = await orderRepository.FindById(OrderId);
            if (order == null)
                throw new ServiceException($"Order with Id {OrderId} does not exist.");
            order.Clear();
            unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="OrdersManager.Application.Exceptions.ServiceException"></exception>
        public virtual async Task Delete(Guid OrderId)
        {
            Order order = await orderRepository.FindById(OrderId);
            if (order == null)
                throw new ServiceException($"Order with Id {OrderId} does not exist.");

            await orderRepository.Remove(order);
            unitOfWork.Commit();
        }
    }
}
