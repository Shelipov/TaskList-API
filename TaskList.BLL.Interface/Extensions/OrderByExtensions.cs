using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Enums;

namespace TaskList.BLL.Interface.Extensions
{
    public static class OrderByExtensions
    {
        public static IOrderedQueryable<TSource> OrderField<TSource, TKey>(this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector, OrderBy orderBy)
        {
            return orderBy == OrderBy.Asc
                ? source.OrderBy(keySelector)
                : source.OrderByDescending(keySelector);
        }
    }
}
