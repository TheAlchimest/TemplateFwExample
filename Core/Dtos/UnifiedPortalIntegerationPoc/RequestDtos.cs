using Newtonsoft.Json;
using UnifiedPortalIntegerationPoc.Enums;

namespace UnifiedPortalIntegerationPoc.Dto
{
    public class TempUserData
    {
        public string UserId { get; set; }
        public string FoundationNo { get; set; }

    }

    #region GenericServiceIntegration
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GenericServiceIntegrationCountRequest
    {
        public string ServiceCode { get; set; }
        public RequestStatus? Status { get; set; }

        public string FoundationNo { get; set; }

        public ProcessType? ProcessType { get; set; }

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GenericServiceIntegrationRequestsData
    {
        public string RequestNo { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public RequestStatus? Status { get; set; }
        public SortingType? OrderBy { get; set; } = SortingType.Latest;
        public string FoundationNo { get; set; }
        public ProcessType? ProcessType { get; set; }
        public string ServiceCode { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GenericServiceIntegrationRequestsStatistics
    {
        public string ServiceCode { get; set; }
        public string FoundationNo { get; set; }
        public ProcessType? ProcessType { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GenericServiceIntegrationAssetsCountRequest
    {
        public string FoundationNo { get; set; }
        public string ServiceCode { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GenericServiceIntegrationAssetsDataRequest
    {
        public string FoundationNo { get; set; }
        public string ServiceCode { get; set; }
    }
    #endregion

    #region InternalGenericServiceIntegration
    public class InternalGenericServiceIntegrationRequestsData : GenericServiceIntegrationRequestsData
    {
        public int ServiceId { get; set; }
    }
    public class InternalGenericServiceIntegrationRequestsStatistics : GenericServiceIntegrationRequestsStatistics
    {
        public int ServiceId { get; set; }
    }

    public class InternalGenericServiceIntegrationAssetsDataRequest : GenericServiceIntegrationAssetsDataRequest
    {
        public int ServiceId { get; set; }
    }
    #endregion

    #region Individual
    public class IndividualCountRequest
    {
        public RequestStatus? Status { get; set; }
    }

    public class IndividualRequestsRequest
    {
        public string RequestNo { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public RequestStatus? Status { get; set; }
        public SortingType? OrderBy { get; set; } = SortingType.Latest;
    }
    #endregion

    #region Foundation (Business,Govenment)
    public class FoundationCountRequest : IndividualCountRequest
    {
        public string FoundationNo { get; set; }
    }
    public class FoundationStatisticsRequest
    {
        public string FoundationNo { get; set; }
    }
    public class FoundationAssetsRequest
    {
        public string FoundationNo { get; set; }
    }
    public class FoundationRequestsRequest : IndividualRequestsRequest
    {
        public string FoundationNo { get; set; }
    }
    #endregion

    #region Operator(Service Provider,Security)
    //Operator ----------------------
    public class OperatorCountRequest : FoundationCountRequest
    {
        public ProcessType? ProcessType { get; set; }

    }
    public class OperatorStatistics : FoundationStatisticsRequest
    {
        public ProcessType? ProcessType { get; set; }
    }
    public class OperatorRequestsRequest : FoundationRequestsRequest
    {
        public ProcessType? ProcessType { get; set; }
    }
    public class OperatorAssetsRequest : FoundationAssetsRequest
    {
    }
    #endregion
    public enum ProcessType
    {
        Tracking = 1,
        Processing = 2
    }
}
