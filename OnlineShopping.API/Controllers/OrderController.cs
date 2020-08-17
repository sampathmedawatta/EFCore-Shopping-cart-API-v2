using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models.Order;
using System;

using System.Threading.Tasks;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager, ILogger<UserController> logger)
        {
            _logger = logger;
            _orderManager = orderManager;
        }

        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Order/gfgf=-23232-v-343
        ///  [AllowAnonymous]
        [HttpGet()]
        public async Task<ActionResult<OperationResult>> GetAsync(Guid Id)
        {
            _logger.LogInformation("Get order by id");
            var operationResult = await _orderManager.GetOrderByIdAsync(Id);

            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);

        }


        /// <summary>
        /// Method to get products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET: api/Order/History/gfgf=-23232-v-343
        ///  [AllowAnonymous]
        [HttpGet("History")]
        public async Task<ActionResult<OperationResult>> GetAllByCustomerIdAsync(Guid Id)
        {
            _logger.LogInformation("Get order by id");
            var operationResult = await _orderManager.GetAllByCustomerIdAsync(Id);

            if (operationResult.Data == null)
            {
                return NotFound(operationResult);
            }
            return Ok(operationResult);

        }

        /// <summary>
        /// placeOrder
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OperationResult>> placeOrder([FromBody] OrderDto orderDto)
        {
            _logger.LogInformation("Create new order");
            var operationResult = await _orderManager.CreateOrderAsync(orderDto);

            return Ok(operationResult);
        }
    }
}