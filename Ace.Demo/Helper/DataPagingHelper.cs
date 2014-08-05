using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Ace.Demo.Helper
{
    /// <summary>
    /// 分页排序助手类
    /// </summary>
    public static class DataPagingHelper
    {
        public static IQueryable<T> GetQueryable<T>(this IList<T> list, string sidx, string sord, int page, int rows)
        {
            return GetQueryable<T>(list.AsQueryable<T>(), sidx, sord, page, rows);
        }

        public static IQueryable<T> GetQueryable<T>(this IQueryable<T> queriable, string sidx, string sord, int page, int rows)
        {
            var data = ApplyOrder<T>(queriable, sidx, sord.ToLower() == "asc" ? true : false);

            return data.Skip<T>((page - 1) * rows).Take<T>(rows);
        }

        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> queriable, string property, bool isASC)
        {
            PropertyInfo pi = typeof(T).GetProperty(property);
            ParameterExpression arg = Expression.Parameter(typeof(T), "x");
            Expression expr = Expression.Property(arg, pi);

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), pi.PropertyType);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            string methodName = isASC ? "OrderBy" : "OrderByDescending";

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), pi.PropertyType)
                    .Invoke(null, new object[] { queriable, lambda });

            return (IOrderedQueryable<T>)result;
        }
    }
}