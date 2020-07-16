using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/GetAllProducts/id?A5010212-DBDF-4460-B4F5-2EAF139F254A
        [HttpGet("ProductById/{id:Guid}")]
        public OperationResult Get(Guid id)
        {
            _logger.LogInformation("this is sample log");
            OperationResult operationResult = _productManager.GetAllProducts(id);
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
            OperationResult operationResult = _productManager.GetAllProducts(null);
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
            OperationResult operationResult = _productManager.GetProductsByOptions("FeatureProducts");
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
            OperationResult operationResult = _productManager.GetProductsByOptions("HomePageProducts");
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
            OperationResult operationResult = _productManager.GetProductsByCategoryName(CategoryName);
            return operationResult;
        }
    }
}
