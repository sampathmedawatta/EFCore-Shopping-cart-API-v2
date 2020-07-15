using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        ProductManager _productManager;

        #endregion
        public ProductController(IOptions<AppSettings> appSetting, IMapper mapper)
        {

            // TODO DI for product manager
            // handle exception and log
            // return error code and route Action Result
            // 

            AppSettings configSettings = appSetting.Value;

            ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration
            {
                ConnectionString = configSettings.ConnectionString
            };

            //TODO call from statup DI
            this._productManager = new ProductManager(applicationConfiguration, mapper);
        }



        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/GetAllProducts/id?A5010212-DBDF-4460-B4F5-2EAF139F254A


        // TODO change router to get
        [HttpGet("ProductById/{id:Guid}")]
        public OperationResult Get(Guid id)
        {
            //  TODO try catch
            OperationResult operationResult = _productManager.GetAllProducts(id);

            // TODO to change OK and Action result
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
