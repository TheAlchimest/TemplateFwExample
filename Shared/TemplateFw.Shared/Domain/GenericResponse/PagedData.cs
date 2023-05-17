using System.Collections.Generic;

namespace TemplateFwExample.Shared.Domain.GenericResponse
{
    public class PagedData<T>
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IList<T> Data { get; set; }

    }
}
