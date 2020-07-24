using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.ManagerClasses.Interfaces;
using OnlineShopping.Common;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.User;
using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEntry"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<bool> CheckPasswordAsync(Guid id, string password)
        {
            return await _unitOfWork.Users.CheckPasswordAsync(id, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task<CustomerDto> GetByEmailAsync(string Email)
        {
            return await _unitOfWork.Users.GetByEmailAsync(Email);
        }


        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult> GetAllUsersAsync()
        {
            // get all users from generic repository
            OperationResult operationResult = new OperationResult();
            operationResult.Data = await _unitOfWork.UserGenericRepository.GetAll();

            return validateResult(operationResult, true);
        }

        public async Task<OperationResult> CreateUserAsync(CustomerDto customerDto)
        {
            OperationResult operationResult = new OperationResult();

            customerDto.IsActive = true;
            customerDto.CustomerRoleId = Guid.Parse("F9B8A3F4-736E-484E-B2F7-08763339F95C");  // TODO get role id from DB

            customerDto.User = customerDto;

            bool result = await (_unitOfWork.Users.Insert(customerDto)) > 0;

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
