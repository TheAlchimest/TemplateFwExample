namespace TemplateFwExample.Dtos.Portal.Integration
{
    public class ServiceRequestsCountItemDto
    {
        public string Name { get; set; } = "";
        public int Id { get; set; }
        public string Icon { get; set; }
        public string ApiUrl { get; set; }
        public int? Count { get; set; }
        public int? TrackingCount { get; set; }
        public int? ProcessingCount { get; set; }
        public int TaskId { get; set; }
        public bool ShowRequestsDataInFollowUp { get; set; }
        public string ServiceCode { get; set; }
    }

    public class ServiceAssetsCountItemDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string ApiUrl { get; set; }
        public int? Count { get; set; }
        public int TaskId { get; set; }
        public bool ShowAssetsDataInAssets { get; set; }
        public string ServiceCode { get; set; }
    }
}
