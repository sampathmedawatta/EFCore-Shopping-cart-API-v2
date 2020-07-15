using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.ManagerClasses;
using OnlineShopping.Common;
using System;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region properties
        ProductManager productManager;
        private readonly ILogger _logger;

        #endregion
        public ProductController(ILogger<ProductController> logger, IOptions<AppSettings> appSetting, IMapper mapper)
        {
            AppSettings configSettings = appSetting.Value;

            _logger = logger;
            ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration
            {
                ConnectionString = configSettings.ConnectionString
            };

            this.productManager = new ProductManager(applicationConfiguration, mapper);
        }



        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/GetAllProducts/id?A5010212-DBDF-4460-B4F5-2EAF139F254A
        [HttpGet("ProductById/{id:Guid}")]
        public OperationResult Get(Guid id)
        {
            _logger.LogInformation("this is sample log");
            OperationResult operationResult = productManager.GetAllProducts(id);
            return operationResult;
        }

        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/GetAllProducts/

        [HttpGet("AllProducts")]
        public OperationResult Get()
        {
            _logger.LogInformation("this is sample log");
            OperationResult operationResult = productManager.GetAllProducts(null);
            return operationResult;
        }

        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/GetFeatureProducts/

        [HttpGet("FeatureProducts")]
        public OperationResult GetFeatureProducts()
        {
            OperationResult operationResult = productManager.GetProductsByOptions("FeatureProducts");
            return operationResult;
        }


        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/GetHomePageProducts/

        [HttpGet("HomePageProducts")]
        public OperationResult GetHomePageProducts()
        {
            OperationResult operationResult = productManager.GetProductsByOptions("HomePageProducts");
            return operationResult;
        }

        /// <summary>
        /// Method to get products by Category Name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/GetHomePageProducts/

        [HttpGet("ProductsByCategory/{CategoryName}", Name = "ProductsByCategoryName")]
        public OperationResult GetAllByCategoryName(string CategoryName)
        {
            OperationResult operationResult = productManager.GetProductsByCategoryName(CategoryName);
            return operationResult;
        }
    }
}
