using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Repository;

namespace OnlineShopping.Business.ManagerClasses
{
    public class BaseManager : IBaseManager
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
        public BaseManager(IOptions<AppSettings> appSetting)
        {
            AppSettings configSettings = appSetting.Value;
            ConnectionString = configSettings.ConnectionString;
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
