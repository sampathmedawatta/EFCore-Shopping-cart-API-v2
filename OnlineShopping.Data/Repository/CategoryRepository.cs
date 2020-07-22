using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;

namespace OnlineShopping.Data.Repository
{
    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {

        private readonly DbSet<CategoryEntity> table;
        private readonly IMapper _mapper;

        public CategoryRepository(OnlineShoppingContext context, IMapper mapper) : base(context)
        {

            table = context.Set<CategoryEntity>();
            _mapper = mapper;
        }

    }
}
