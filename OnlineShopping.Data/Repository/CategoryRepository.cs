using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<CategoryEntity> table;
        public CategoryRepository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<CategoryEntity>();
        }
        public async Task<IEnumerable<CategoryEntity>> GetAllAsunc()
        {
            return await table.Where(p => p.IsActive.Equals(true)).ToListAsync();
        }


        public async Task<CategoryEntity> GetByIdAsunc(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task<int> Insert(CategoryEntity entity)
        {
            this.context.Categories.Add(entity);
            int excecutedRows = await this.context.SaveChangesAsync();

            return excecutedRows;
        }

        public void Update(CategoryEntity entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            CategoryEntity existing = table.Find(id);
            table.Remove(existing);
        }
    }
}
