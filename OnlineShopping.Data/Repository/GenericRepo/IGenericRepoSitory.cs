using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineShopping.Data.Repository.GenericRepo
{

    ///https://gist.github.com/mcnkbr/f96532254f62a384878f
    public interface IGenericRepoSitory<TModel, TDto>
        where TModel : class
        where TDto : class
    {
        List<TDto> GetAll(bool mapReset = true);
        List<TDto> FindBy(Expression<Func<TModel, bool>> predicate, bool mapReset = true);

        void Add(TDto entity);
        void Add(TModel entity);
        int Add(TDto entity, bool returnId, string returnName);

        void Delete(Expression<Func<TModel, bool>> predicate);

        void Edit(TDto entity, bool hasMap = false);
        void Save();
    }
}
