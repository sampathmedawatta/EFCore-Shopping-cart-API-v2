using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineShopping.API.Auth;
using OnlineShopping.API.Auth.Interfaces;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models;
using OnlineShopping.Entity.Models.User;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ITokenRefresher _tokenRefresher;
        private readonly ApplicationSettings _appsettings;
        private readonly IUserManager _userManager;
        private readonly ILogger _logger;

        public UserController(IUserManager userManager, ITokenGenerator tokenGenerator, ITokenRefresher tokenRefresher, IOptions<ApplicationSettings> appsettings, ILogger<UserController> logger)
        {
            _tokenGenerator = tokenGenerator;
            _tokenRefresher = tokenRefresher;
            _appsettings = appsettings.Value;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("Profile")]
        //GET : /api/User/Profile
        public async Task<ActionResult<OperationResult>> GetUserProfile()
        {
            Guid UserId = Guid.Parse(User.Claims.First(
                c => c.Type == "UserId").Value);

            var operationResult = await _userManager.GetById(UserId);

            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);
        }

        /// <summary>
        /// Method to get Useres
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/User/

        [HttpGet]
        public async Task<ActionResult<OperationResult>> GetAsync()
        {

            _logger.LogInformation("Get Category List");
            var operationResult = await _userManager.GetAllUsersAsync();
            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<OperationResult>> RegisterUser([FromBody] CustomerDto customerDto)
        {
            _logger.LogInformation("Create new user");
            var operationResult = await _userManager.CreateUserAsync(customerDto);

            return Ok(operationResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]

        //POST : /api/User/Login
        public async Task<ActionResult<OperationResult>> LoginAsync(LoginDto loginDto)
        {
            OperationResult operationResult = new OperationResult();

            if (loginDto.Email == null || loginDto.Password == null)
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enums.Status.Error;
                operationResult.Message = Constant.FailMessage;
                operationResult.Error = "Incorrect Login request";

                return BadRequest(operationResult);
            }

            var user = await _userManager.GetByEmailAsync(loginDto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user.Id, loginDto.Password))
            {
                var key = _appsettings.JWT_Secret;
                AuthanticationResponse authanticationResponse = _tokenGenerator.GenerateToken(key, user.Id);

                if (authanticationResponse == null)
                {
                    operationResult.StatusId = 400;
                    operationResult.Status = Enums.Status.Error;
                    operationResult.Message = Constant.FailMessage;
                    operationResult.Error = "No Records Found";

                    return Unauthorized(operationResult);
                }

                operationResult.StatusId = 200;
                operationResult.Status = Enums.Status.Success;
                operationResult.Message = Constant.SuccessMessage;
                operationResult.Data = authanticationResponse;

                return Ok(operationResult);
            }

            operationResult.StatusId = 400;
            operationResult.Status = Enums.Status.Error;
            operationResult.Message = Constant.FailMessage;
            operationResult.Error = "Invalid login details";
            return Unauthorized(operationResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RefreshTokenDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public ActionResult<OperationResult> Refresh([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var key = _appsettings.JWT_Secret;
            OperationResult operationResult = new OperationResult();
            AuthanticationResponse authanticationResponse = _tokenRefresher.Refresh(refreshTokenDto, key);

            if (authanticationResponse == null)
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enums.Status.Error;
                operationResult.Message = Constant.FailMessage;
                operationResult.Error = "No Records Found";

                return Unauthorized(operationResult);
            }

            operationResult.StatusId = 200;
            operationResult.Status = Enums.Status.Success;
            operationResult.Message = Constant.SuccessMessage;
            operationResult.Data = authanticationResponse;

            return Ok(operationResult);
        }
    }
}