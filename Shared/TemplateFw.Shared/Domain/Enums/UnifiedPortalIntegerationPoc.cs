using TemplateFwExample.Shared.Configuration;

namespace UnifiedPortalIntegerationPoc.Enums
{
    /*
    public enum RequestStatuses
    {
        Completed = 6
    }
    */
    public enum SortingType
    {
        Latest = 1,
        Oldest = 2,
        Status = 3
    }
    public enum RequestStatus
    {
        [OpenApiIgnoreEnum]
        All = 0,
        Draft = 1,
        Recieved = 2,
        UnderProcessing = 3,
        NeedAction = 4,
        Closed = 5,
        Canceled = 6,
        [OpenApiIgnoreEnum]
        Active = 10
    }
}
