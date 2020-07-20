using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses
{
    public class CategoryManager : BaseManager, ICategoryManager
    {

        public CategoryManager(IOptions<AppSettings> appSetting, IMapper mapper) : base(appSetting, mapper)
        {
        }

        public async Task<OperationResult> GetCategoriesAsunc()
        {
            // new operation result object to hold response data
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await CategoryData.GetCategoriesAsunc();

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
