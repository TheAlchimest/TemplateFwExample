using System;
using System.Collections.Generic;

#nullable disable

namespace UnifiedPortalIntegerationPoc.Dto
{



    public class RequestsPagingDto
    {
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IEnumerable<RequestSummaryItemDto> Requests { get; set; }
    }
    public class AssetsDataDto
    {
        public IEnumerable<AssetSummaryItemDto> Assets { get; set; }
    }
    public class RequestSummaryItemDto
    {
        public int RequestId { get; set; }
        public string RequestType { get; set; }
        public string RequestNo { get; set; }
        public int RequestStatusId { get; set; }
        public string RequestStatus { get; set; }
        public string RequestActivity { get; set; }
        public string ServiceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string RequestUrl { get; set; }

    }
    public class AssetSummaryItemDto
    {
        public int AssetId { get; set; }
        public string AssetNo { get; set; }
        public string AssetStatus { get; set; }
        public string ServiceName { get; set; }
        public string FoundationNo { get; set; }
        public string AssetUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    public class RequestSubTypeStatsItemDto
    {
        public string SubTypeName { get; set; }
        public int Count { get; set; }
    }

    public class RequestSummaryDto
    {
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IEnumerable<RequestSummaryItemDto> Requests { get; set; }
    }
    public class StatisticsDto
    {
        public int TotalRequests { get; set; }
        public int CompletedRequests { get; set; }
        public int PendingRequests { get; set; }
        public decimal CompletedRequestsPecentage {
            get {
                decimal percentage = 0;
                if (TotalRequests > 0)
                {
                    percentage = ((CompletedRequests * 100) / TotalRequests);
                }
                return Math.Round(percentage, 0);
            }
        }
        public List<RequestSubTypeStatsItemDto> SubTypes { get; set; }
    }
    public class AssetsSummaryDto
    {
        public IEnumerable<AssetSummaryItemDto> Assets { get; set; }
    }
    public class OperatorRequestCountDto
    {
        public int Tracking { get; set; }
        public int Processing { get; set; }
    }
    public class OperatorRequestSummaryDto
    {
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IEnumerable<OperatorRequestSummaryItemDto> Requests { get; set; }
    }
    public class OperatorRequestSummaryItemDto : RequestSummaryItemDto
    {

        public string ProcessType { get; set; }
        public int ProcessTypeId { get; set; }
    }

    public class OperatorStatisticsDto
    {
        public StatisticsDto Tracking { get; set; }
        public StatisticsDto Processing { get; set; }
    }
}
