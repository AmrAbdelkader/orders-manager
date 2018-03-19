using AutoMapper;
using OrdersManager.Application.Orders;
using OrdersManager.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersManager.Application.Mappings
{
    class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Order, OrderDto>();
            //Mapper.CreateMap<CartProduct, CartProductDto>();

            //Mapper.CreateMap<Purchase, CheckOutResultDto>()
            //    .ForMember(x => x.PurchaseId, options => options.MapFrom(x => x.Id));

            //Mapper.CreateMap<CreditCard, CreditCardDto>();
            //Mapper.CreateMap<Customer, CustomerDto>();
            //Mapper.CreateMap<Product, ProductDto>();
            //Mapper.CreateMap<CustomerPurchaseHistoryReadModel, CustomerPurchaseHistoryDto>();
            //Mapper.CreateMap<DomainEventRecord, EventDto>();
        }
    }
}
