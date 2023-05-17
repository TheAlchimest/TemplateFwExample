namespace TemplateFwExample.Shared.Configuration
{
    public class SystemConfiguration
    {
        public WebSettings WebSettings { get; set; }
        public int DefaultLanguage { get; set; }
        public int DefaultPageSize { get; set; }
        public int PortalId { get; set; }
        public string LandingURL { get; set; }
        public string LoggingDBConnection { get; set; }
    }

    public class LoggingWriteTo
    {
        public string Name { get; set; }
        public LoggingWriteToArgs Args { get; set; }
    }

    public class LoggingWriteToArgs
    {
        public string TableName { get; set; }
    }
}
