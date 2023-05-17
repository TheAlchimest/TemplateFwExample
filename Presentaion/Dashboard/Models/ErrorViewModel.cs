namespace TemplateFwExample.Dashboard.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErrorVm
    {
        public string Title { get; set; }
        public string ErrorCodes { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }

    }

}
