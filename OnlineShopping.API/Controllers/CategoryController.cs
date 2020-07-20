using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        #region properties
        private readonly ICategoryManager _categoryManager;
        private readonly ILogger _logger;
        #endregion

        public CategoryController(ICategoryManager categoryManager, ILogger<ProductController> logger, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _logger = logger;
        }


        /// <summary>
        /// Method to get Categories
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Category/

        [HttpGet]
        public OperationResult Get()
        {
            _logger.LogInformation("this is sample log");
            OperationResult operationResult = _categoryManager.GetAllCategories(null);
            return operationResult;
        }
    }
}
