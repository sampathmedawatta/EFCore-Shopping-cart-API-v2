using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using System.Threading.Tasks;

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

        public CategoryController(ICategoryManager categoryManager, ILogger<CategoryController> logger)
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
        public async Task<ActionResult<OperationResult>> GetAsunc()
        {

            _logger.LogInformation("Get Category List");
            var operationResult = await _categoryManager.GetCategoriesAsunc();
            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);

        }


    }
}
