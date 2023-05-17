using UnifiedPortalIntegerationPoc.Dto;
using UnifiedPortalIntegerationPoc.Enums;

namespace TemplateFwExample.Dtos.Portal.Integration
{
    public class PaginationParameter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Direction { get; set; } = "asc";
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public int LanguageId { get; set; } = 1;
    }
    public class RequestGridFilter
    {
        public int ServiceId { get; set; }
        public string RequestNo { get; set; }
        public RequestStatus Status { get; set; }
        public SortingType OrderBy { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class OperatorRequestGridFilter
    {
        public int ServiceId { get; set; }
        public string RequestNo { get; set; }
        public RequestStatus Status { get; set; }
        public SortingType OrderBy { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public ProcessType? ProcessType { get; set; }

    }

}
