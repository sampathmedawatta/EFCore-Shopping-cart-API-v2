using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Common;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Category;
using OnlineShopping.Entity.Models.Product;
using OnlineShopping.Entity.Models.User;

namespace OnlineShopping.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string ConnectionString;
        public IProductRepository<ProductDto> Products { get; private set; }
        public ICategoryRepository<CategoryDto> Categories { get; private set; }
        public IUserRepository<UserDto> Users { get; private set; }

        private OnlineShoppingContext Context
        {
            get
            {
                return new OnlineShoppingContext(ConnectionString);
            }
        }
        public UnitOfWork(IOptions<AppSettings> appSetting, IMapper mapper)
        {

            ConnectionString = appSetting.Value.ConnectionString;

            Products = new ProductRepository(Context, mapper);
            Categories = new CategoryRepository(Context, mapper);
            Users = new UserRepository(Context, mapper);

        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
