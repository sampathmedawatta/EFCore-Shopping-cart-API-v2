using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.User;

namespace OnlineShopping.Data.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // login CreateMap<CustomerEntry, UserReadDto>();
            CreateMap<UserCreateDto, CustomerEntry>();
            CreateMap<UserRegisterDto, CustomerPasswordEntry>();


        }
    }
}
