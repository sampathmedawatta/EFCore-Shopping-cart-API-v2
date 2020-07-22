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
        public UnitOfWork(IOptions<AppSettings> appSetting)
        {
            //AppSettings configSettings = appSetting.Value;
            //ConnectionString = configSettings.ConnectionString;

            ConnectionString = appSetting.Value.ConnectionString;

            Products = new ProductRepository(Context);
            Categories = new CategoryRepository(Context);
            Users = new UserRepository(Context);
            UserPasswords = new UserPasswordRepository(Context);

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
