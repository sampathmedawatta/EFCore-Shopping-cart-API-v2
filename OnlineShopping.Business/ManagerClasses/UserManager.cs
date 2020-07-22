using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.User;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses
{
    public class UserManager : IUserManager
    {
        private IUnitOfWork _unitOfWork;
        public UserManager(IUnitOfWork unitOfWork, IOptions<AppSettings> appSetting, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> CreateUserAsunc(UserCreateDto userCreateDto)
        {
            // TODO fix create user
            OperationResult operationResult = new OperationResult();
            bool result = false; //await _unitOfWork.Users.Insert(userCreateDto);

            return validateResult(operationResult, result);
        }

        private OperationResult validateResult(OperationResult operationResult, bool result)
        {
            if (result)
            {
                operationResult.StatusId = 200;
                operationResult.Status = Enum.Status.Success;
                operationResult.Message = Constant.SuccessMessage;
            }
            else
            {
                operationResult.StatusId = 400;
                operationResult.Status = Enum.Status.Error;
                operationResult.Message = Constant.FailMessage;
                operationResult.Error = "Records Not Saved";
            }


            return operationResult;
        }
    }
}
