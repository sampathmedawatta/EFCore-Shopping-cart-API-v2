using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class UserPasswordRepository : IRepository<CustomerPasswordEntry>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<CustomerPasswordEntry> table;
        public UserPasswordRepository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<CustomerPasswordEntry>();
        }

        public async Task<int> Insert(CustomerPasswordEntry entity)
        {
            this.context.CustomerPasswords.Add(entity);
            return await this.context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerPasswordEntry>> GetAllAsunc()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerPasswordEntry> GetByIdAsunc(Guid id)
        {
            throw new NotImplementedException();
        }



        public void Update(CustomerPasswordEntry entity)
        {
            throw new NotImplementedException();
        }
    }
}
