using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Data.Data;
using System.Threading.Tasks;
using Enum = OnlineShopping.Common.Enum;

namespace OnlineShopping.Business.ManagerClasses
{
    public class ProductManager : BaseManager, IProductManager
    {


        public ProductManager(IOptions<AppSettings> appSetting, IMapper mapper) : base(appSetting, mapper)
        {
        }

        public async Task<OperationResult> GetProductsAsunc()
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await ProductData.GetProductsAsunc();

            return validateResult(operationResult);
        }

        public async Task<OperationResult> GetProductsByCategoryNameAsunc(string Name)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await ProductData.GetProductsByCategoryNameAsunc(Name);

            return validateResult(operationResult);
        }

        public async Task<OperationResult> GetProductsByOptionsAsunc(string option)
        {
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await ProductData.GetProductsByOptionsAsunc(option);

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
