﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using System.Threading.Tasks;

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
        public async Task<ActionResult<OperationResult>> GetAsunc()
        {
            _logger.LogInformation("Get Product List");
            var operationResult = await _productManager.GetProductsAsunc();

            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);

        }


        /// <summary>
        /// Method to get Feature products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetFeatureProducts/

        [HttpGet("FeatureProducts")]
        public async Task<ActionResult<OperationResult>> GetFeatureProductsAsunc()
        {
            var operationResult = await _productManager.GetProductsByOptionsAsunc("FeatureProducts");
            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);
        }


        /// <summary>
        /// Method to get Home Page products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetHomePageProducts/

        [HttpGet("HomePageProducts")]
        public async Task<ActionResult<OperationResult>> GetHomePageProductsAsunc()
        {
            var operationResult = await _productManager.GetProductsByOptionsAsunc("HomePageProducts");
            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);
        }

        /// <summary>
        /// Method to get products by Category Name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetHomePageProducts/

        [HttpGet("ProductsByCategory/{CategoryName}", Name = "ProductsByCategoryName")]
        public async Task<ActionResult<OperationResult>> GetAllByCategoryNameAsunc(string CategoryName)
        {
            var operationResult = await _productManager.GetProductsByCategoryNameAsunc(CategoryName);
            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);
        }
    }
}
