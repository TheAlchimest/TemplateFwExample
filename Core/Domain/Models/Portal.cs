#nullable disable

namespace TemplateFwExample.Domain.Models
{
    public partial class Portal
    {
        public Portal()
        {
        }

        public int PortalId { get; set; }
        public string Link { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsAvailable { get; set; }
    }
}
