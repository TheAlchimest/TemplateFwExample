using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TemplateFw.Persistence.Extensions
{
    public static class DbSetExtensions
    {
        public static Task<Language> GetDefaultLanguageAsync(this IQueryable<Language> queryable)
            => queryable.FirstOrDefaultAsync(l => l.IsDefault);
    }

    public static class ListExtensions
    {
        public static void VirtualRemove<T>(this List<T> list, Func<T, bool> predicate = null) where T : BaseEntity
        {
            if (predicate is not null) list = list.Where(predicate).ToList();

            list.ForEach(c =>
            {
                c.IsActive = false;
            });
        }
    }
}
