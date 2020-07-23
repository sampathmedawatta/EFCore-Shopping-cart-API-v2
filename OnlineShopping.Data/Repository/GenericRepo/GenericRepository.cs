using AutoMapper;
using OnlineShopping.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.Data.Repository.GenericRepo
{
    public abstract class GenericRepository<TModel, TDto> : IGenericRepoSitory<TModel, TDto>
        where TModel : class
        where TDto : class

    {

        private OnlineShoppingContext context;
        private IMapper _mapper;

        public GenericRepository(OnlineShoppingContext context, IMapper mapper)
        {

            this.context = context;
            _mapper = mapper;
        }

        public List<TDto> GetAll(bool mapReset = true)
        {
            var ent = this.context.Set<TModel>();
            var query = ent.ToList();

            //TODO fix this issue - reset() is not found

            // if (mapReset)
            //    _mapper.Reset();
            var list = MapToDtoList<TModel, TDto>(query).ToList();
            return list;
        }

        public virtual IEnumerable<_TDto> MapToDtoList<_TEntity, _TDto>(IEnumerable<_TEntity> entity)
            where _TEntity : class
            where _TDto : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<_TEntity, _TDto>();
            });

            _mapper = config.CreateMapper();

            return _mapper.Map<IEnumerable<_TEntity>, IEnumerable<_TDto>>(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
