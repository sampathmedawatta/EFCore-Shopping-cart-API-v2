using OnlineShopping.Common;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Repository;

namespace OnlineShopping.Data.Data
{
    public class BaseData
    {
        private readonly string ConnectionString;

        private ProductRepository productRepository;
        public ProductRepository ProductRepository
        {
            get
            {
                productRepository = productRepository ?? new ProductRepository(Context);
                return productRepository;
            }
        }

        private OnlineShoppingContext Context
        {
            get
            {
                return new OnlineShoppingContext(ConnectionString);
            }
        }

        public BaseData(ApplicationConfiguration applicationConfiguration)
        {
            ConnectionString = applicationConfiguration.ConnectionString;
        }

    }
}
