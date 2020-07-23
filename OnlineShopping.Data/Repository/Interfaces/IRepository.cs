using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Interfaces.Repository
{

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);
        Task<int> Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
