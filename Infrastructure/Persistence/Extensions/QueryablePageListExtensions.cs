using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Persistence.Extensions
{
    public static class QueryablePageListExtensions
    {
        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}"/> by the specified <paramref name="pageIndex"/> and <paramref name="pageSize"/>.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
        /// </param>
        /// <param name="indexFrom">The start index value.</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}"/> interface.</returns>
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, PaginationFilter filter)
        {
            return await query.ToPagedListAsync<T>(filter.PageNumber, filter.PageSize);
        }

        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int pageNo, int pageSize, string orderBy = "", CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            int pageIndex = pageNo - 1;
            var count = await query.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = new List<T>();
            if (count > 0)
                items = await query.Skip(pageIndex * pageSize)
                    .Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<T>(items, pageNo, pageSize, count);
            return pagedList;
        }
    }
}
