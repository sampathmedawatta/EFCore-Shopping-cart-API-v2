using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.Order;

namespace OnlineShopping.Data.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrderDto, OrderEntry>();
        }
    }
}
