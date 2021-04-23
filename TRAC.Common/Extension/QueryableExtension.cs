using System;
using System.Linq;
using System.Linq.Expressions;

namespace TRAC.Common.Extension
{
    public static class QueryableExtension
    {
        public static IQueryable<TM> OrderBy<TM>(this IQueryable<TM> source, string orderByProperty,
                  bool asc) where TM : class
        {
            var command = asc ? "OrderBy" : "OrderByDescending";
            var type = typeof(TM);
            var parameter = Expression.Parameter(type, "p");
            string[] PropertyName = orderByProperty.Split('.');
            MemberExpression propertyAccess = (!orderByProperty.Contains('.')) ?
                    Expression.Property(parameter, PropertyName[0]) :
                    Expression.Property(Expression.Property(parameter, PropertyName[0]), PropertyName[1]);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new[] { type, propertyAccess.Type },
                source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TM>(resultExpression);
        }
    }
}
