using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class CategoryRepository : ICategoryRepository<CategoryDto>
    {
        protected OnlineShoppingContext context = null;
        private readonly DbSet<CategoryEntity> table;
        private readonly IMapper _mapper;

        public CategoryRepository(OnlineShoppingContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<CategoryEntity>();
            _mapper = mapper;
        }


        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {

            var productList = await table.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(productList);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await table.FindAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public Task<int> Insert(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
