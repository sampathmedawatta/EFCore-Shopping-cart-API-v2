using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Order;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> CreateOrderAsync(OrderDto orderDto)
        {
            OperationResult operationResult = new OperationResult();

            orderDto.Id = new Guid();
            bool result = await (_unitOfWork.Orders.Insert(orderDto)) > 0;

            return validateResult(operationResult, result);
        }

        private OperationResult validateResult(OperationResult operationResult, bool result)
        {
            if (result)
            {
                operationResult.StatusId = 200;
                operationResult.Status = Enums.Status.Success;
                operationResult.Message = Constant.SuccessMessage;
            }
            else
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enums.Status.Error;
                operationResult.Message = Constant.FailMessage;
                operationResult.Error = "Records Not Saved";
            }


            return operationResult;
        }
    }
}
