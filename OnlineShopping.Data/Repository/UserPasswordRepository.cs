using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;

namespace OnlineShopping.Data.Repository
{
    public class UserPasswordRepository : Repository<CustomerPasswordEntry>, IUserPasswordRepository
    {

        private readonly DbSet<CustomerPasswordEntry> table;
        private readonly IMapper _mapper;

        public UserPasswordRepository(OnlineShoppingContext context, IMapper mapper) : base(context)
        {

            table = context.Set<CustomerPasswordEntry>();
            _mapper = mapper;
        }

    }
}
