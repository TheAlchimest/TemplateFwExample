using System;
using System.Collections.Generic;

namespace TemplateFwExample.Shared.Domain.GenericResponse
{
    public class PaginatedList<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new List<T>();
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageNumber = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            this.Items.AddRange(items);
        }

        public bool PreviousPage => (PageNumber > 1);
        public bool NextPage => (PageNumber < TotalPages);

        public static PaginatedList<T> Create(List<T> items, int count, int pageIndex, int pageSize)
        {
            return new(items, count, pageIndex, pageSize);
        }
    }
}
