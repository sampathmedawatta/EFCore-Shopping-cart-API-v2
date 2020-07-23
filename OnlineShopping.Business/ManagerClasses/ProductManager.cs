using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Data.Repository.Interfaces;
using System.Threading.Tasks;
using Enum = OnlineShopping.Common.Enum;

namespace OnlineShopping.Business.ManagerClasses
{
    public class ProductManager : IProductManager
    {
        private IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork, IOptions<AppSettings> appSetting, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> GetProductsAsunc()
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.Products.GetAllAsync();

            return validateResult(operationResult);
        }

        public async Task<OperationResult> GetProductsByCategoryNameAsunc(string Name)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.Products.GetAllByCategoryNameAsunc(Name);

            return validateResult(operationResult);
        }

        public async Task<OperationResult> GetProductsByOptionsAsunc(string option)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.Products.GetAllByFilterAsunc(option);

            return validateResult(operationResult);
        }
        private OperationResult validateResult(OperationResult operationResult)
        {
            if (operationResult.Data == null)
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enum.Status.Error;
                operationResult.Message = Constant.FailMessage;
                operationResult.Error = "No Records Found";
            }
            else
            {
                operationResult.StatusId = 200;
                operationResult.Status = Enum.Status.Success;
                operationResult.Message = Constant.SuccessMessage;
            }
            return operationResult;
        }

    }
}
