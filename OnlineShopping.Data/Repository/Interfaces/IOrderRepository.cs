using OnlineShopping.Data.Interfaces.Repository;
using OnlineShopping.Entity.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IOrderRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<OrderDto>> GetAllByCustomerIdAsync(Guid id);
    }
}
