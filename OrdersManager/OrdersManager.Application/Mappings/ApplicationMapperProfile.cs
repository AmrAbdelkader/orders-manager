using AutoMapper;
using OrdersManager.Application.Items;
using OrdersManager.Application.Orders;
using OrdersManager.Core.Items;
using OrdersManager.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Application.Mappings
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Item, ItemDto>();


            CreateMap<OrderItem, OrderItemOutputModel>();
            
            //Mapper.CreateMap<DomainEventRecord, EventDto>();
        }
    }
}
