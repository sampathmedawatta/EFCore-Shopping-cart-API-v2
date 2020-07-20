using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    // TODO : implement common properties and operations (CRUD)
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsunc();

        Task<T> GetByIdAsunc(Guid id);
        Task<int> Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
