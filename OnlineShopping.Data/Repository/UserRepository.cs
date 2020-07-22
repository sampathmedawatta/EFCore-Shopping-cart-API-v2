using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;

namespace OnlineShopping.Data.Repository
{
    public class UserRepository : Repository<CustomerEntry>, IUserRepository
    {

        private readonly DbSet<CustomerEntry> table;
        private readonly IMapper _mapper;

        public UserRepository(OnlineShoppingContext context, IMapper mapper) : base(context)
        {

            table = context.Set<CustomerEntry>();
            _mapper = mapper;
        }
    }
}
