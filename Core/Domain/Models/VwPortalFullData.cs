#nullable disable

namespace TemplateFwExample.Domain.Models
{
    public partial class VwPortalFullData
    {
        public int PortalId { get; set; }
        public bool IsAvailable { get; set; }
        public string Link { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
