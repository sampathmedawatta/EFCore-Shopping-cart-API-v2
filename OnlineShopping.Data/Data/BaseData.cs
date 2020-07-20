using OnlineShopping.Data.Context;
using OnlineShopping.Data.Repository;

namespace OnlineShopping.Data.Data
{
    public class BaseData
    {
        private readonly string ConnectionString;
        #region Private Properties
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;
        private UserPasswordRepository userPasswordRepository;
        private OnlineShoppingContext Context
        {
            get
            {
                return new OnlineShoppingContext(ConnectionString);
            }
        }

        //TODO add connection string
        public BaseData(string applicationConfiguration)
        {

            ConnectionString = applicationConfiguration;
        }
        #endregion
        #region Public Properties

        /// <summary>
        /// Product Repository Public Property
        /// </summary>
        public ProductRepository ProductRepository
        {
            get
            {
                productRepository = productRepository ?? new ProductRepository(Context);
                return productRepository;
            }
        }

        /// <summary>
        /// Product Repository Public Property
        /// </summary>
        public CategoryRepository CategoryRepository
        {
            get
            {
                categoryRepository = categoryRepository ?? new CategoryRepository(Context);
                return categoryRepository;
            }
        }

        /// <summary>
        /// User Repository Public Property
        /// </summary>
        public UserRepository UserRepository
        {
            get
            {
                userRepository = userRepository ?? new UserRepository(Context);
                return userRepository;
            }
        }

        /// <summary>
        /// User Repository Public Property
        /// </summary>
        public UserPasswordRepository UserPasswordRepository
        {
            get
            {
                userPasswordRepository = userPasswordRepository ?? new UserPasswordRepository(Context);
                return userPasswordRepository;
            }
        }
        #endregion
    }
}
