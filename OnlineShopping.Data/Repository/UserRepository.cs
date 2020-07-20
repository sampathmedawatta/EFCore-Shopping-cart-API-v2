using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class UserRepository : IRepository<CustomerEntry>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<CustomerEntry> table;
        public UserRepository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<CustomerEntry>();
        }

        public async Task<int> Insert(CustomerEntry entity)
        {
            this.context.Customers.Add(entity);
            return await this.context.SaveChangesAsync();

        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerEntry>> GetAllAsunc()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerEntry> GetByIdAsunc(Guid id)
        {
            throw new NotImplementedException();
        }



        public void Update(CustomerEntry entity)
        {
            throw new NotImplementedException();
        }
    }
}
