namespace TemplateFwExample.Shared.Dto
{
    public class UserRegisteredNumbersDto
    {
        public string Mobile { get; set; }
        public string Provider { get; set; }
        public string SubscriptionAr { get; set; }
        public string SubscriptionEn { get; set; }
        public string StatusAr { get; set; }
        public string StatusEn { get; set; }
    }

    public class UserRegisteredNumbersViewDto
    {
        public string Mobile { get; set; }
        public string Provider { get; set; }
        public string Subscription { get; set; }
        public string Status { get; set; }
        public int ServiceType { get; set; }
        public int SubscriptionType { get; set; }
    }

    public class UserRegisteredAddressDto
    {
        public string Result { get; set; }

        public string BuildingNumber { get; set; }

        public string AdditionalNumber { get; set; }

        public string ZipCode { get; set; }

        public string UnitNumber { get; set; }

        public string DistrictAreaArabic { get; set; }

        public string DistrictAreaEnglish { get; set; }

        public string StreetNameArabic { get; set; }

        public string StreetNameEnglish { get; set; }

        public string CityNameArabic { get; set; }

        public string CityNameEnglish { get; set; }

        public string FullName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
