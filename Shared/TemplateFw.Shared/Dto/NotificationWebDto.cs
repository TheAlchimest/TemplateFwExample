using System.Collections.Generic;

namespace TemplateFwExample.Shared.Dto
{
    public class NotificationWebDto
    {
        public string ServiceName { get; set; }
        public List<NotificationWebDetailDto> Details { get; set; }
        public string Link { get; set; }
    }
}
