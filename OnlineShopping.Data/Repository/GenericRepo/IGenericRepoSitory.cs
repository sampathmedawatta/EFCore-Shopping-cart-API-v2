using System.Collections.Generic;

namespace OnlineShopping.Data.Repository.GenericRepo
{

    ///https://gist.github.com/mcnkbr/f96532254f62a384878f
    public interface IGenericRepoSitory<TModel, TDto>
        where TModel : class
        where TDto : class
    {
        List<TDto> GetAll(bool mapReset = true);
        void Save();
    }
}
