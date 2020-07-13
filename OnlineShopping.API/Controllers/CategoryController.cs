using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.ManagerClasses;
using OnlineShopping.Common;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        #region properties
        CategoryManager categoryManager;

        #endregion

        public CategoryController(IOptions<AppSettings> appSetting, IMapper mapper)
        {
            AppSettings configSettings = appSetting.Value;

            ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration
            {
                ConnectionString = configSettings.ConnectionString
            };

            this.categoryManager = new CategoryManager(applicationConfiguration, mapper);
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
            OperationResult operationResult = categoryManager.GetAllCategories(null);
            return operationResult;
        }
    }
}
