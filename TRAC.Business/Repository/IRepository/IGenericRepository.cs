using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TRAC.Business.Repository.IRepository
{
    public interface IGenericRepository<TM, TD>
        where TM : class
        where TD : class
    {
        Task<TD> Add(TD entity);
        Task<bool?> Any(Expression<Func<TM, bool>> predicate);
        void Delete(Expression<Func<TM, bool>> predicate);
        void Edit(TD entity);
        Task<IEnumerable<TD>> FindBy(Expression<Func<TM, bool>> predicate);
        Task<IEnumerable<TD>> GetAll();
        IQueryable<TM> List(Expression<Func<TM, bool>> filter = null, Func<IQueryable<TM>, IOrderedQueryable<TM>> orderBy = null, List<Expression<Func<TM, object>>> includeProperties = null, int? page = null, int? pageSize = null);
        IQueryable<TM> List(Expression<Func<TM, bool>> filter = null, string orderBy = null, string ascendingDescending = "ASC", List<Expression<Func<TM, object>>> includeProperties = null, int? page = null, int? pageSize = null);
        Tuple<IQueryable<TM>, int> ListWithPaging(Expression<Func<TM, bool>> filter = null, Func<IQueryable<TM>, IOrderedQueryable<TM>> orderBy = null, List<Expression<Func<TM, object>>> includeProperties = null, int? page = null, int? pageSize = null);
        Tuple<IQueryable<TM>, int> ListWithPaging(Expression<Func<TM, bool>> filter = null, string orderBy = null, string ascendingDescending = "ASC", List<Expression<Func<TM, object>>> includeProperties = null, int? page = null, int? pageSize = null);
        IEnumerable<TDto> MapToDtoList<TEntity, TDto>(IEnumerable<TEntity> entity)
            where TEntity : class
            where TDto : class;
      
        Task<int> Save();
        Task<TD> SingleOrDefault(Expression<Func<TM, bool>> predicate);
        IQueryable<TD> ToDtoListPaging(IQueryable<TD> list, string orderBy = null, string ascendingDescending = "ASC", int? page = null, int? pageSize = null);
    }
}