using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.User;

namespace OnlineShopping.Data.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<CustomerEntry, CustomerDto>();
            CreateMap<CustomerDto, CustomerEntry>();
            CreateMap<UserDto, CustomerPasswordEntry>()
                 .ForMember(dest =>
                dest.Customer,
                opt => opt.MapFrom(src => src.User))
                ;
        }
    }
}
