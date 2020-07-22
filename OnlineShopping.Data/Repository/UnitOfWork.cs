using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Common;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Repository.Interfaces;

namespace OnlineShopping.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string ConnectionString;
        public IProductRepository Products { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IUserRepository Users { get; private set; }

        public IUserPasswordRepository UserPasswords { get; private set; }

        private OnlineShoppingContext Context
        {
            get
            {
                return new OnlineShoppingContext(ConnectionString);
            }
        }
        public UnitOfWork(IOptions<AppSettings> appSetting, IMapper mapper)
        {
            //AppSettings configSettings = appSetting.Value;
            //ConnectionString = configSettings.ConnectionString;

            ConnectionString = appSetting.Value.ConnectionString;

            Products = new ProductRepository(Context, mapper);
            Categories = new CategoryRepository(Context, mapper);
            Users = new UserRepository(Context, mapper);
            UserPasswords = new UserPasswordRepository(Context, mapper);

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
