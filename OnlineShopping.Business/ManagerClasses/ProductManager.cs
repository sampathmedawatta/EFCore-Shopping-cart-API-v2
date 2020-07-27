using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Data.Repository.Interfaces;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses
{
    public class ProductManager : IProductManager
    {
        private IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> GetProductsAsync()
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.Products.GetAllAsync();

            return validateResult(operationResult);
        }

        public async Task<OperationResult> GetProductsByCategoryNameAsync(string Name)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.Products.GetAllByCategoryNameAsync(Name);

            return validateResult(operationResult);
        }

        public async Task<OperationResult> GetProductsByOptionsAsync(string option)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.Products.GetAllByFilterAsync(option);

            return validateResult(operationResult);
        }
        private OperationResult validateResult(OperationResult operationResult)
        {
            if (operationResult.Data == null)
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enums.Status.Error;
                operationResult.Message = Constant.FailMessage;
                operationResult.Error = "No Records Found";
            }
            else
            {
                operationResult.StatusId = 200;
                operationResult.Status = Enums.Status.Success;
                operationResult.Message = Constant.SuccessMessage;
            }
            return operationResult;
        }

    }
}
