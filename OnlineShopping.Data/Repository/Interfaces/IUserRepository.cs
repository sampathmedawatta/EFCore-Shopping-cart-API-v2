using OnlineShopping.Data.Interfaces.Repository;
using OnlineShopping.Entity.Models.User;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        Task<CustomerDto> GetByEmailAsync(string Email);
        Task<bool> CheckPasswordAsync(Guid id, string password);
    }
}
