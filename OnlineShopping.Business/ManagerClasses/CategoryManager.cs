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

        /// <summary>
        /// method get all products 
        /// /// </summary>
        /// <param name="id"> if if need to be filtered </param>
        /// <returns></returns>

        public async Task<OperationResult> GetCategories()
        {
            // new operation result object to hold response data
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await CategoryData.GetCategories();

            if (operationResult.Data == null)
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enum.Status.Error;
                operationResult.Message = Constant.FailMessage;
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
