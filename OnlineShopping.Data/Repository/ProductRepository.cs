using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : IProductRepository<ProductDto>
    {

        private readonly DbSet<ProductEntiry> table;
        private readonly IMapper _mapper;

        public ProductRepository(OnlineShoppingContext context, IMapper mapper)
        {

            table = context.Set<ProductEntiry>();
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetAllByFilterAsync(string FilterBy)
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
                return _mapper.Map<IEnumerable<ProductDto>>(productList);
            }
            else if (FilterBy.Equals("HomePageProducts"))
            {
                var productList = await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(p => p.ShowInHomePage.Equals(true))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
                return _mapper.Map<IEnumerable<ProductDto>>(productList);
            }

            else if (FilterBy.Equals("All"))
            {
                var productList = await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(p => p.ShowInHomePage.Equals(true))
               .Where(p => p.IsFeatureProduct.Equals(true))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
                return _mapper.Map<IEnumerable<ProductDto>>(productList);
            }

            return null;
        }

        public async Task<IEnumerable<ProductDto>> GetAllByCategoryNameAsync(string CategoryName)
        {

            var productList = await table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(ct => ct.Category.Name.Equals(CategoryName))
               .Where(p => p.IsActive.Equals(true)).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(productList);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var productList = await table
                 .Include(c => c.Category)
                 .Include(u => u.UnitType)
                 .Include(p => p.Picture)
                 .Where(p => p.IsActive.Equals(true)).ToListAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(productList);
        }

        public Task<ProductDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
