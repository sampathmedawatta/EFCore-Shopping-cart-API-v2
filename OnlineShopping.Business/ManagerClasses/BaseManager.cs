using OnlineShopping.Common;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Repository;

namespace OnlineShopping.Business.ManagerClasses
{
    public class BaseManager
    {
        private readonly string ConnectionString;
        #region Private Properties
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private OnlineShoppingContext Context
        {
            get
            {
                return new OnlineShoppingContext(ConnectionString);
            }
        }
        public BaseManager(ApplicationConfiguration applicationConfiguration)
        {
            ConnectionString = applicationConfiguration.ConnectionString;
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
        #endregion
    }
}
