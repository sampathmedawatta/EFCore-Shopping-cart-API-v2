using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.Order;
using OnlineShopping.Entity.Models.PaymentMethod;

namespace OnlineShopping.Data.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            //Get Order Details
            CreateMap<OrderItemEntry, OrderItemDto>()
                .ForMember(dest =>
               dest.Price,
               opt => opt.MapFrom(src => src.UnitPrice));
            CreateMap<OrderEntry, DeliveryDetailsDto>();
            CreateMap<PaymentMethodEntry, PaymentMethodDto>();
            CreateMap<OrderEntry, OrderDto>()
            .ForMember(dest =>
            dest.TotalAmount,
            opt => opt.MapFrom(src => src.OrderTotal))
            .ForMember(dest =>
            dest.SubTotal,
            opt => opt.MapFrom(src => src.SubTotal))
            .ForMember(dest =>
            dest.Tax,
            opt => opt.MapFrom(src => src.Tax))
            .ForMember(dest =>
                dest.PaymentMethodId,
                opt => opt.MapFrom(src => src.PaymentMethodId))
            .ForMember(dest =>
                dest.OrderDate,
                opt => opt.MapFrom(src => src.OrderDate))
             .ForMember(dest =>
             dest.PaymentMethod,
             opt => opt.MapFrom(src => src.PaymentMethod))
             .ForMember(dest =>
            dest.DeliveryDetails,
            opt => opt.MapFrom(src => src))
            .ForMember(dest =>
            dest.OrderItems,
            opt => opt.MapFrom(src => src.OrderItemEntries));



            //Set order details
            CreateMap<OrderItemDto, OrderItemEntry>()
                 .ForMember(dest =>
                dest.UnitPrice,
                opt => opt.MapFrom(src => src.Price));
            CreateMap<OrderDto, OrderEntry>()
                .ForMember(dest =>
                dest.OrderTotal,
                opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest =>
                dest.SubTotal,
                opt => opt.MapFrom(src => src.SubTotal))
                .ForMember(dest =>
                dest.Tax,
                opt => opt.MapFrom(src => src.Tax))
                 .ForMember(dest =>
                dest.PaymentMethodId,
                opt => opt.MapFrom(src => src.PaymentMethodId))
                 .ForMember(dest =>
                dest.CustomerId,
                opt => opt.MapFrom(src => src.DeliveryDetails.Id))
                 .ForMember(dest =>
                dest.Email,
                opt => opt.MapFrom(src => src.DeliveryDetails.Email))
                 .ForMember(dest =>
                dest.FirstName,
                opt => opt.MapFrom(src => src.DeliveryDetails.FirstName))
                  .ForMember(dest =>
                dest.LastName,
                opt => opt.MapFrom(src => src.DeliveryDetails.LastName))
                   .ForMember(dest =>
                dest.AddressLine1,
                opt => opt.MapFrom(src => src.DeliveryDetails.AddressLine1))
                    .ForMember(dest =>
                dest.AddressLine2,
                opt => opt.MapFrom(src => src.DeliveryDetails.AddressLine2))
                     .ForMember(dest =>
                dest.State,
                opt => opt.MapFrom(src => src.DeliveryDetails.State))
                      .ForMember(dest =>
                dest.PostCode,
                opt => opt.MapFrom(src => src.DeliveryDetails.PostCode))
                       .ForMember(dest =>
                dest.OrderItemEntries,
                opt => opt.MapFrom(src => src.OrderItems))
                ;
        }
    }
}
