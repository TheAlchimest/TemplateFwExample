using System;
using System.Collections.Generic;

namespace TemplateFwExample.Dtos.UserAccounts
{
    public class GovernmentAccountCreateRequestDto
    {
        public Guid FoundationAccountId { get; set; }
        public string FoundationNo { get; set; }
        public string NationalNo { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? CrCountryId { get; set; }
        public string FoundationField { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public int? ZipCode { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Domain { get; set; }
        public string Tel { get; set; }
        public int? WaselNo { get; set; }
        public int FoundationTypeId { get; set; }
        public int AccountStatusId { get; set; }
        public string Comment { get; set; }
        public int? BlockReasonId { get; set; }
        public string BlockReasonNote { get; set; }

        public string AccountEmail { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public FoundationAccountLoginDto UserLogin { get; set; }
        public List<FoundationContactCreateRequestDto> FoundationContacts { get; set; }
        public List<int> FoundationCategories { get; set; }

    }


    public class FoundationAccountLoginDto
    {
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public string AccountEmail { get; set; }

    }

    public partial class FoundationContactCreateRequestDto
    {
        public string BirthDate { get; set; }
        public Guid ContactId { get; set; }
        //public int ContactId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public long IdNumber { get; set; }
        public string Mobile { get; set; }
        public string Posission { get; set; }

        public long? Tel { get; set; }


        //public Guid FoundationAccountId { get; set; }

        //public long CountryId { get; set; }
        public bool IsAccountManager { get; set; }
        //public bool IsAvailable { get; set; }
    }
}
