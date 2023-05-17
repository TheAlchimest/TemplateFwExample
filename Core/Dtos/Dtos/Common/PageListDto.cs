using System;
using System.Collections.Generic;

namespace TemplateFwExample.Dtos.Common
{
    public class PageListDto<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public bool ShowPageIndex {
            get {
                if (TotalCount > PageSize)
                    return true;
                return false;
            }
        }

        public int PageIndexCount {
            get {
                if (PageSize == 0)
                    return 0;
                var totalPageIndex = Math.Floor(Convert.ToDecimal(TotalCount / PageSize));
                if (TotalCount % PageSize > 0)
                    totalPageIndex++;
                return Convert.ToInt32(totalPageIndex);
            }
        }

        public List<T> Result { get; set; }
    }
}
