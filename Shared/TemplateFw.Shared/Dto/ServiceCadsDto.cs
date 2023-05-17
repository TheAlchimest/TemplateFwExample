using TemplateFw.Shared.Domain.Enums;
using System;
using System.Collections.Generic;

namespace TemplateFw.Shared.Dto
{
    public class ServiceCardDto
    {
        public int ServiceId { get; set; }
        public int PortalId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public string Icon { get; set; }
        public string CategoryIcon { get; set; }
        public int ServiceBaseId { get; set; }
        public ServiceType Type { get; set; }
        public string Category { get; set; }
        public bool IsFavorite { get; set; }
        public string ServiceCode { get; set; }
        public int? ServiceSectorId { get; set; }
        public bool LogInRequired { get; set; }

        public string Url { get; set; }

    }
    public class ServiceCategoryDto { 
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int ServicesCounts { get; set; }
    }

    public class ServiceCategoryViewDto
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int ServicesCounts { get; set; }
        public string Icon { get; set; }
    }

    public class ServiceCatalogDto
    {
        public List<ServiceCardDto> Services { get; set; }
        public List<ServiceCategoryViewDto> Categories { get; set; }
        public int TotalServices { get; set; }
    }
    public class TopServicesCatalogDto
    {
        public List<ServiceCardDto> TopServices { get; set; }
        public int TotalServices { get; set; }
    }

    public class ServiceCatalogLookupFilterDto
    {
        public int PortalId { get; set; }
        public int LangId { get; set; }
        public string FoundationCategories { get; set; }
    }
    public class ServiceCatalogFilterDto
    {
        public Guid? UserID { get; set; }
        public int UserTypeId { get; set; }
        public int PortalId { get; set; }
        public int LangId { get; set; }
        public string FoundationCategories { get; set; } = null;
        public int TopCount { get; set; }
        public int? ServiceType { get; set; }
    }
}
