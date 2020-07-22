using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : Repository<ProductEntiry>, IProductRepository
    {

        private readonly DbSet<ProductEntiry> table;
        public ProductRepository(OnlineShoppingContext context) : base(context)
        {

            table = context.Set<ProductEntiry>();
        }

        public async Task<IEnumerable<ProductEntiry>> GetAllProductsAsunc()
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


    }
}
