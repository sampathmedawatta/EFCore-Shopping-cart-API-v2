using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models;
using OnlineShopping.Entity.Models.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationSettings _appsettings;
        private readonly IUserManager _userManager;
        private readonly ILogger _logger;

        public UserController(IUserManager userManager, IOptions<ApplicationSettings> appsettings, ILogger<UserController> logger)
        {
            _appsettings = appsettings.Value;
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
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.GetByEmailAsync(loginDto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user.Id, loginDto.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });
            }

            return BadRequest(new { message = "incorrect login details" });
        }
    }
}