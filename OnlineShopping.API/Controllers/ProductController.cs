using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        #region properties
        private readonly IProductManager _productManager;
        private readonly ILogger _logger;

        #endregion
        public ProductController(IProductManager productManager, ILogger<ProductController> logger, IMapper mapper)
        {
            _productManager = productManager;
            _logger = logger;

        }



        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product
        [HttpGet()]
        public OperationResult Get()
        {
            _logger.LogInformation("Get Product List");
            OperationResult operationResult = _productManager.GetProducts();
            return operationResult;
        }


        /// <summary>
        /// Method to get Feature products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetFeatureProducts/

        [HttpGet("FeatureProducts")]
        public OperationResult GetFeatureProducts()
        {
            OperationResult operationResult = _productManager.GetProductsByOptions("FeatureProducts");
            return operationResult;
        }


        /// <summary>
        /// Method to get Home Page products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetHomePageProducts/

        [HttpGet("HomePageProducts")]
        public OperationResult GetHomePageProducts()
        {
            OperationResult operationResult = _productManager.GetProductsByOptions("HomePageProducts");
            return operationResult;
        }

        /// <summary>
        /// Method to get products by Category Name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetHomePageProducts/

        [HttpGet("ProductsByCategory/{CategoryName}", Name = "ProductsByCategoryName")]
        public OperationResult GetAllByCategoryName(string CategoryName)
        {
            OperationResult operationResult = _productManager.GetProductsByCategoryName(CategoryName);
            return operationResult;
        }
    }
}
