using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.GenericRepo
{
    ///
    /// Sample link for Generic automapping with generic repository
    ///https://gist.github.com/mcnkbr/f96532254f62a384878f
    public interface IGenericRepository<TModel, TDto>
        where TModel : class
        where TDto : class
    {
        Task<List<TDto>> GetAll(bool mapReset = true);
        Task<List<TDto>> FindBy(Expression<Func<TModel, bool>> predicate, bool mapReset = true);

        void Add(TDto entity);
        void Add(TModel entity);
        int Add(TDto entity, bool returnId, string returnName);

        void Delete(Expression<Func<TModel, bool>> predicate);

        void Edit(TDto entity, bool hasMap = false);
        void Save();
    }
}
