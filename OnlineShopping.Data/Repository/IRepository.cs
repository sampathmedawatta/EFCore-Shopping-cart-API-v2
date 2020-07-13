using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Repository
{
    // TODO : implement common properties and operations (CRUD)
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
