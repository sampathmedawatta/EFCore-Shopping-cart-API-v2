using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OnlineShopping.Data.Repository.GenericRepo
{
    public static class QueryableExtensions
    {
        public static IQueryable<TModel> OrderBy<TModel>(this IQueryable<TModel> source, string orderByProperty,
                      bool asc) where TModel : class
        {
            var command = asc ? "OrderBy" : "OrderByDescending";
            var type = typeof(TModel);
            PropertyInfo property;
            if (!orderByProperty.Contains('.'))
                property = type.GetProperties().FirstOrDefault(w => w.Name == orderByProperty);
            else
            {
                var arrg = orderByProperty.Split('.');
                property = type.GetProperty(arrg[0]).GetType().GetProperty(arrg[1]);
            }
            var parameter = Expression.Parameter(type, "p");
            if (property == null) return null;
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TModel>(resultExpression);
        }


        /// <summary>
        /// This is a fix for above function  : " OrderBy extension will not work correctly for nested properties. I suggest you write it like this "
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="source"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public static IQueryable<TModel> OrderByIssueFixed<TModel>(this IQueryable<TModel> source, string orderByProperty,
                  bool asc) where TModel : class
        {
            var command = asc ? "OrderBy" : "OrderByDescending";
            var type = typeof(TModel);
            var parameter = Expression.Parameter(type, "p");
            string[] PropertyName = orderByProperty.Split('.');
            MemberExpression propertyAccess = (!orderByProperty.Contains('.')) ?
                    Expression.Property(parameter, PropertyName[0]) :
                    Expression.Property(Expression.Property(parameter, PropertyName[0]), PropertyName[1]);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new[] { type, propertyAccess.Type },
                source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TModel>(resultExpression);
        }
    }
}
