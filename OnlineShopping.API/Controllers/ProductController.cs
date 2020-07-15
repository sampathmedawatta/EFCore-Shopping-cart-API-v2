using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models.Product;
using System;
using System.Collections.Generic;

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
            // handle exception and log
            // return error code and route Action Result

            AppSettings configSettings = appSetting.Value;

            _logger = logger;
            ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration
            {
                ConnectionString = configSettings.ConnectionString
            };

            // TODO DI for product manager
            this._productManager = new ProductManager(applicationConfiguration, mapper);
        }


        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/

        [HttpGet()]
        public ActionResult<IEnumerable<ProductReadDto>> Get()
        {
            _logger.LogInformation("this is sample log");
            //  TODO try catch check exception and return relevent response 404 200 201
            return Ok(_productManager.GetProducts());
        }

        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Product/id?A5010212-DBDF-4460-B4F5-2EAF139F254A

        // TODO change router to get
        [HttpGet("{id:Guid}")]
        public ActionResult<ProductReadDto> Get(Guid id)
        {
            _logger.LogInformation("this is sample log");
            //  TODO try catch check exception and return relevent response 404 200 201
            return Ok(_productManager.GetProductById(id));
        }


        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetFeatureProducts/

        [HttpGet("FeatureProducts")]
        public ActionResult<IEnumerable<ProductReadDto>> GetFeatureProducts()
        {
            //  TODO try catch check exception and return relevent response 404 200 201
            return Ok(_productManager.GetProductsByOptions("FeatureProducts"));
        }


        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetHomePageProducts/

        [HttpGet("HomePageProducts")]
        public ActionResult<IEnumerable<ProductReadDto>> GetHomePageProducts()
        {
            //  TODO try catch check exception and return relevent response 404 200 201
            return Ok(_productManager.GetProductsByOptions("HomePageProducts"));
        }

        /// <summary>
        /// Method to get products by Category Name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Product/GetHomePageProducts/

        [HttpGet("ProductsByCategory/{CategoryName}", Name = "ProductsByCategoryName")]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllByCategoryName(string CategoryName)
        {
            //  TODO try catch check exception and return relevent response 404 200 201
            return Ok(_productManager.GetProductsByCategoryName(CategoryName));
        }
    }
}
