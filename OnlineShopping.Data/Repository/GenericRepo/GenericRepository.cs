using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public List<TDto> FindBy(Expression<Func<TModel, bool>> predicate, bool mapReset = true)
        {
            var ent = this.context.Set<TModel>();
            var query = ent.Where(predicate).ToList();

            // if (mapReset)
            //     Mapper.Reset();

            var list = MapToDtoList<TModel, TDto>(query).ToList();
            return list;
        }

        public virtual void Add(TDto entity)
        {
            // Mapper.Reset();
            // Mapper.CreateMap<TD, TM>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDto, TModel>();
            });

            _mapper = config.CreateMapper();

            var item = _mapper.Map<TDto, TModel>(entity);

            this.context.Set<TModel>().Add(item);
            Save();
        }

        public virtual void Add(TModel entity)
        {
            this.context.Set<TModel>().Add(entity);
            Save();
        }

        public virtual int Add(TDto entity, bool returnId, string returnName)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDto, TModel>();
            });

            _mapper = config.CreateMapper();

            var item = _mapper.Map<TDto, TModel>(entity);

            this.context.Set<TModel>().Add(item);
            Save();
            return returnId ? (int)item.GetType().GetProperty(returnName).GetValue(item, null) : 0;
        }

        public virtual TModel AddGetId(TDto entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDto, TModel>();
            });

            _mapper = config.CreateMapper();

            var item = _mapper.Map<TDto, TModel>(entity);

            this.context.Set<TModel>().Add(item);
            Save();
            return item;
        }

        public virtual void Delete(Expression<Func<TModel, bool>> predicate)
        {
            this.context.Set<TModel>().RemoveRange(this.context.Set<TModel>().Where(predicate));
            Save();
        }

        public virtual void Edit(TDto entity, bool hasMap = false)
        {
            if (!hasMap)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TDto, TModel>();
                });

                _mapper = config.CreateMapper();
            }

            var participationDto = _mapper.Map<TDto, TModel>(entity);

            this.context.Set<TModel>().Attach(participationDto);
            this.context.Entry(participationDto).State = EntityState.Modified;

            Save();
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

        public virtual IEnumerable<_TEntity> MapToEntityList<_TDto, _TEntity>(IEnumerable<_TDto> dto)
           where _TDto : class
           where _TEntity : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<_TDto, _TEntity>();
            });

            _mapper = config.CreateMapper();


            return _mapper.Map<IEnumerable<_TDto>, IEnumerable<_TEntity>>(dto);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
