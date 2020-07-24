using OnlineShopping.Common;
using OnlineShopping.Entity.Models.User;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses.Interfaces
{
    public interface IUserManager
    {
        Task<OperationResult> CreateUserAsync(CustomerDto customerDto);
        Task<OperationResult> GetAllUsersAsync();

        Task<OperationResult> GetById(Guid id);
        Task<CustomerDto> GetByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(Guid id, string password);

    }
}
