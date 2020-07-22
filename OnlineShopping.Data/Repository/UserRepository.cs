using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;

namespace OnlineShopping.Data.Repository
{
    public class UserRepository : Repository<CustomerEntry>, IUserRepository
    {

        private readonly DbSet<CustomerEntry> table;
        public UserRepository(OnlineShoppingContext context) : base(context)
        {

            table = context.Set<CustomerEntry>();
        }
    }
}
