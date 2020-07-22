using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : Repository<ProductEntiry>, IProductRepository
    {

        private readonly DbSet<ProductEntiry> table;
        private readonly IMapper _mapper;

        public ProductRepository(OnlineShoppingContext context, IMapper mapper) : base(context)
        {

            table = context.Set<ProductEntiry>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsunc()
        {
            var productList = await table
                .Include(c => c.Category)
                .Include(u => u.UnitType)
                .Include(p => p.Picture)
                .Where(p => p.IsActive.Equals(true)).ToListAsync();


            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);

        }
        public async Task<IEnumerable<ProductReadDto>> GetAllByFilterAsunc(string FilterBy)
        {

            if (FilterBy.Equals("FeatureProducts"))
            {
                var productList = await table
                  .Include(c => c.Category)
                  .Include(u => u.UnitType)
                  .Include(p => p.Picture)
                  .Where(p => p.IsActive.Equals(true))
                  .Where(p => p.IsFeatureProduct.Equals(true))
                  .ToListAsync();
                return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
            }
            else if (FilterBy.Equals("HomePageProducts"))
            {
                var productList = await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(p => p.ShowInHomePage.Equals(true))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
                return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
            }

            return null;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllByCategoryNameAsunc(string CategoryName)
        {

            var productList = await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(ct => ct.Category.Name.Equals(CategoryName))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
        }


    }
}
