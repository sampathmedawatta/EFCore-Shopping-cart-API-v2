using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : IRepository<ProductEntiry>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<ProductEntiry> table;
        public ProductRepository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<ProductEntiry>();
        }

        public async Task<IEnumerable<ProductEntiry>> GetAllAsunc()
        {
            return await table
                .Include(c => c.Category)
                .Include(u => u.UnitType)
                .Include(p => p.Picture)
                .Where(p => p.IsActive.Equals(true)).ToListAsync();
        }
        public async Task<IEnumerable<ProductEntiry>> GetAllByFilterAsunc(string FilterBy)
        {

            if (FilterBy.Equals("FeatureProducts"))
            {
                return await table
                  .Include(c => c.Category)
                  .Include(u => u.UnitType)
                  .Include(p => p.Picture)
                  .Where(p => p.IsActive.Equals(true))
                  .Where(p => p.IsFeatureProduct.Equals(true))
                  .ToListAsync();
            }
            else if (FilterBy.Equals("HomePageProducts"))
            {
                return await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(p => p.ShowInHomePage.Equals(true))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
            }

            return null;
        }

        public async Task<IEnumerable<ProductEntiry>> GetAllByCategoryNameAsunc(string CategoryName)
        {

            return await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(ct => ct.Category.Name.Equals(CategoryName))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
        }


        public async Task<ProductEntiry> GetByIdAsunc(Guid id)
        {
            return await table.FindAsync(id);
        }

        public void Insert(ProductEntiry entity)
        {
            table.Add(entity);
        }

        public void Update(ProductEntiry entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            ProductEntiry existing = table.Find(id);
            table.Remove(existing);
        }

    }
}
