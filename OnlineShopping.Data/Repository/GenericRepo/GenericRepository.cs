using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.GenericRepo
{
    public abstract class GenericRepository<TModel, TDto> : IGenericRepository<TModel, TDto>
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

        public async Task<List<TDto>> GetAll(bool mapReset = true)
        {
            var ent = this.context.Set<TModel>();
            var query = await ent.ToListAsync();

            //TODO fix this issue - reset() is not found

            // if (mapReset)
            //    _mapper.Reset();
            var list = MapToDtoList<TModel, TDto>(query).ToList();
            return list;
        }

        public async Task<List<TDto>> FindBy(Expression<Func<TModel, bool>> predicate, bool mapReset = true)
        {
            var ent = this.context.Set<TModel>();
            var query = await ent.Where(predicate).ToListAsync();

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

        /// <summary>
        /// IQueryable List with Generic AutoMapper
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQueryable<TModel> List(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>,
            IOrderedQueryable<TModel>> orderBy = null, List<Expression<Func<TModel, object>>> includeProperties = null,
        int? page = null, int? pageSize = null)
        {
            IQueryable<TModel> query = this.context.Set<TModel>();

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (page != null && pageSize != null)
                query = query
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="ascendingDescending"></param>
        /// <param name="includeProperties"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQueryable<TModel> List(Expression<Func<TModel, bool>> filter = null, string orderBy = null, string ascendingDescending = "ASC",
            List<Expression<Func<TModel, object>>> includeProperties = null,
       int? page = null, int? pageSize = null)
        {
            IQueryable<TModel> query = this.context.Set<TModel>();

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (page != null && pageSize != null)
                query = query.OrderBy(orderBy ?? "Id", ascendingDescending == "ASC")
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return query;
        }


        public Tuple<IQueryable<TModel>, int> ListWithPaging(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>,
            IOrderedQueryable<TModel>> orderBy = null, List<Expression<Func<TModel, object>>> includeProperties = null,
        int? page = null, int? pageSize = null)
        {
            IQueryable<TModel> query = this.context.Set<TModel>();

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            var count = query.Count();
            if (page != null && pageSize != null)
                query = query
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return new Tuple<IQueryable<TModel>, int>(query, count);
        }

        public Tuple<IQueryable<TModel>, int> ListWithPaging(Expression<Func<TModel, bool>> filter = null, string orderBy = null, string ascendingDescending = "ASC",
           List<Expression<Func<TModel, object>>> includeProperties = null,
      int? page = null, int? pageSize = null)
        {
            IQueryable<TModel> query = this.context.Set<TModel>();

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            var count = query.Count();

            if (page != null && pageSize != null)
                query = query
                    .OrderBy(orderBy ?? "Id", ascendingDescending == "ASC")
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return new Tuple<IQueryable<TModel>, int>(query, count);
        }

        public IQueryable<TDto> ToDtoListPaging(List<TDto> list, string orderBy = null, string ascendingDescending = "ASC", int? page = null, int? pageSize = null)
        {
            IQueryable<TDto> query = list.AsQueryable();

            if (page != null && pageSize != null)
                query = query
                    .OrderBy(orderBy ?? "Id", ascendingDescending == "ASC")
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return query;
        }
    }
}
