using System;
using System.Collections.Generic;

namespace TemplateFwExample.Shared.Dtos.Collections
{
    public class Pager
    {
        public int PageNumber { get; set; }
        public int PageIndex { get { return PageNumber - 1; } }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get { return PageNumber > 1; } }
        public bool HasNextPage { get { return PageNumber < TotalPages; } }
        public bool IsVisible { get { return TotalPages > 1; } }
        public int PaggingCount { get; set; } = 5;
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int PreviousPageNo { get; set; }
        public int NextPageNo { get; set; }
        public int FirstItemNo { get; set; }

        public Pager()
        {

        }

        public Pager(int pageNumber, int pageSize, int count)
        {
            InitializePagination(pageNumber, pageSize, count);
        }

        private void InitializePagination(int pageNumber, int pageSize, int totalCount)
        {

            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            if (this.PageSize > this.TotalCount)
            {
                PageSize = TotalCount;
            }
            if (this.PaggingCount > this.TotalPages)
            {
                this.PaggingCount = this.TotalPages;
            }
            int previousPages = (int)Math.Ceiling(PaggingCount / (double)2);
            if (PageNumber > previousPages + 1)
            {
                StartPage = PageNumber - previousPages;
            }
            if (StartPage < 1)
            {
                StartPage = 1;
            }

            EndPage = StartPage + PaggingCount - 1;

            if (EndPage > TotalPages)
            {
                EndPage = TotalPages;
            }

            if (EndPage - StartPage < PaggingCount)
            {
                StartPage = EndPage - PaggingCount + 1;
            }

            if (HasPreviousPage)
            {
                PreviousPageNo = PageNumber - 1;
            }

            if (HasNextPage)
            {
                NextPageNo = PageNumber + 1;
            }

            FirstItemNo = ((pageNumber - 1) * pageSize) + 1;
        }
    }
    public class PagedList<T> : Pager
    {
        public PagedList()
        {

        }

        public IEnumerable<T> Items { get; set; }
        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize, int count) : base(pageNumber, pageSize, count)
        {
            Items = source;
        }
    }
}
