using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected OnlineShoppingContext context = null;
        private readonly DbSet<T> table;

        public Repository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task<T> GetByIdAsunc(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task<int> Insert(T entity)
        {
            table.Add(entity);
            int excecutedRows = await this.context.SaveChangesAsync();

            return excecutedRows;
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }
        public void Delete(Guid id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public async Task<IEnumerable<T>> GetAllAsunc()
        {
            return await table.ToListAsync();
        }
    }
}
