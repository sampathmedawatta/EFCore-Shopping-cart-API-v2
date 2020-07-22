using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;

namespace OnlineShopping.Data.Repository
{
    public class UserPasswordRepository : Repository<CustomerPasswordEntry>, IUserPasswordRepository
    {

        private readonly DbSet<CustomerPasswordEntry> table;
        public UserPasswordRepository(OnlineShoppingContext context) : base(context)
        {
            this.context = context;
            table = context.Set<CustomerPasswordEntry>();
        }

    }
}
