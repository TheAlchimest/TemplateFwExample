using System;
using System.Linq.Expressions;

namespace TemplateFwExample.Persistence.Utils
{
    public static class Utilities
    {
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity, TKey>(TKey id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByProperty<TEntity, PropType>(string propName, PropType propValue)
        {
            //Expression.Convert(Expression.Constant(value), column.Type)
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, propName);
            var value = Expression.Constant(propValue);
            //var convert = Expression.Convert(Expression.Constant(value), prop.Type);
            //var equal = Expression.Equal(prop, Expression.Convert(Expression.Constant(value), typeof(PropType)));
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
        public static Expression<Func<TEntity, bool>> MergeTwoPredicates<TEntity>(Expression<Func<TEntity, bool>> predicate1, Expression<Func<TEntity, bool>> predicate2)
        {
            var body = Expression.AndAlso(predicate1.Body, predicate2.Body);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, predicate1.Parameters[0]);
            return lambda;
        }
    }
}
