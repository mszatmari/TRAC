using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRAC.Business.Repository.IRepository;
using TRAC.DataAccess.Data;
using AutoMapper;
using TRAC.Common.Extension;
using Microsoft.Extensions.Logging;

namespace TRAC.Business.Repository
{
    public abstract class GenericRepository<TM, TD> : IGenericRepository<TM, TD> where TM : class
        where TD : class
    {

        private readonly TRACContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GenericRepository<TM,TD>> _logger;

        public GenericRepository(TRACContext context, IMapper mapper, ILogger<GenericRepository<TM, TD>> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<IEnumerable<TD>> GetAll()
        {
            _logger.LogDebug($"get all {typeof(TD)}");
            List<TD> returnValues = new List<TD>();
            try
            {
                var ent = _context.Set<TM>();
                var query = await ent.ToListAsync();
                if (query.Count > 0)
                {
                    returnValues.AddRange(MapToDtoList<TM, TD>(query));
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
           


            return returnValues;
        }

        public async  Task<IEnumerable<TD>> FindBy(Expression<Func<TM, bool>> predicate)
        {
            List<TD> returnValues = new List<TD>();
            try
            {

                var ent = _context.Set<TM>();
                var query = await ent.Where(predicate).ToListAsync();

                if (query.Count > 0)
                {
                    returnValues.AddRange(MapToDtoList<TM, TD>(query));
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
            return returnValues;
        }

        public async Task<TD> SingleOrDefault(Expression<Func<TM, bool>> predicate)
        {
            TD item = null;
            try
            {
                var ent = _context.Set<TM>();
                var query = await ent.SingleOrDefaultAsync(predicate);

                if (query == null)
                    return null;

                item = _mapper.Map<TM, TD>(query);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

            return item;
        }

        public async Task<bool?> Any(Expression<Func<TM, bool>> predicate)
        {
            var result = await _context.Set<TM>().AnyAsync(predicate);
            return result;
        }

        public async virtual Task<TD> Add(TD entity)
        {
            var item = _mapper.Map<TD, TM>(entity);

            var addedentity = await _context.Set<TM>().AddAsync(item);
            await Save();
            return _mapper.Map<TM, TD>(addedentity.Entity);
        }


        public async virtual void Delete(Expression<Func<TM, bool>> predicate)
        {
            _context.Set<TM>().RemoveRange(_context.Set<TM>().Where(predicate));
            await Save();
        }

        public async virtual void Edit(TD entity)
        {

            var participationDto = _mapper.Map<TD, TM>(entity);

            _context.Set<TM>().Attach(participationDto);
            _context.Entry(participationDto).State = EntityState.Modified;

            await Save();
        }

        public virtual async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<TM> List(Expression<Func<TM, bool>> filter = null, Func<IQueryable<TM>,
            IOrderedQueryable<TM>> orderBy = null, List<Expression<Func<TM, object>>> includeProperties = null,
        int? page = null, int? pageSize = null)
        {
            IQueryable<TM> query = _context.Set<TM>();

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

        public IQueryable<TM> List(Expression<Func<TM, bool>> filter = null, string orderBy = null, string ascendingDescending = "ASC",
            List<Expression<Func<TM, object>>> includeProperties = null,
       int? page = null, int? pageSize = null)
        {
            IQueryable<TM> query = _context.Set<TM>();

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (page != null && pageSize != null)
                query = query
                    .OrderBy(orderBy ?? "Id", ascendingDescending == "ASC")
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return query;
        }

        public Tuple<IQueryable<TM>, int> ListWithPaging(Expression<Func<TM, bool>> filter = null, Func<IQueryable<TM>,
            IOrderedQueryable<TM>> orderBy = null, List<Expression<Func<TM, object>>> includeProperties = null,
        int? page = null, int? pageSize = null)
        {
            IQueryable<TM> query = _context.Set<TM>();

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

            return new Tuple<IQueryable<TM>, int>(query, count);
        }

        public Tuple<IQueryable<TM>, int> ListWithPaging(Expression<Func<TM, bool>> filter = null, string orderBy = null, string ascendingDescending = "ASC",
           List<Expression<Func<TM, object>>> includeProperties = null,
      int? page = null, int? pageSize = null)
        {
            IQueryable<TM> query = _context.Set<TM>();

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

            return new Tuple<IQueryable<TM>, int>(query, count);
        }

        public IQueryable<TD> ToDtoListPaging(IQueryable<TD> list, string orderBy = null, string ascendingDescending = "ASC", int? page = null, int? pageSize = null)
        {
            IQueryable<TD> query = list;

            if (page != null && pageSize != null)
                query = query
                    .OrderBy(orderBy ?? "Id", ascendingDescending == "ASC")
                    .Skip(page.Value)
                    .Take(pageSize.Value);

            return query;
        }

        public virtual IEnumerable<TDto> MapToDtoList<TEntity, TDto>(IEnumerable<TEntity> entity)
            where TEntity : class
            where TDto : class
        {

            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entity);
        }

        public virtual IEnumerable<TEntity> MapToEntityList<TDto, TEntity>(IEnumerable<TDto> dto)
            where TDto : class
            where TEntity : class
        {
            return _mapper.Map<IEnumerable<TDto>, IEnumerable<TEntity>>(dto);
        }
    }
}