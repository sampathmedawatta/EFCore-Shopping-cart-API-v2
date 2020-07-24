using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models.User;
using System.Threading.Tasks;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ILogger _logger;

        public UserController(IUserManager userManager, ILogger<UserController> logger)
        {

            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Method to get Useres
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/User/

        [HttpGet]
        public async Task<ActionResult<OperationResult>> GetAsunc()
        {

            _logger.LogInformation("Get Category List");
            var operationResult = await _userManager.GetAllUsersAsync();
            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);

        }



        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<OperationResult>> RegisterUser([FromBody] CustomerDto customerDto)
        {
            _logger.LogInformation("Create new user");
            var operationResult = await _userManager.CreateUserAsync(customerDto);




            return Ok(operationResult);
        }
    }
}