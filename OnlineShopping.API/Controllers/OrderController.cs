using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models.Order;
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