
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFwExample.Resources;
using TemplateFwExample.Resources.Resources;

namespace TemplateFwExample.Dtos
{
    public class ExampleModelDto
    {
        public int ExampleModelId { get; set; }
		public string TitleAr { get; set; }
		public string TitleEn { get; set; }
		public string BriefAr { get; set; }
		public string BriefEn { get; set; }
		public string ContentAr { get; set; }
		public string ContentEn { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string ProfileUrl { get; set; }
		public long IDNumber { get; set; }
		public decimal Amount { get; set; }
		public decimal Price { get; set; }
		public int PostalCode { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime StartHijriDate { get; set; }
		public DateTime EndHijriDate { get; set; }
		public int? ExampleCategoryId { get; set; }
		public int? ExampleStatusId { get; set; }
		public bool IsPublished { get; set; }
		public DateTime PublishingDate { get; set; }
		public string PublishedBy { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class ExampleModelInfoDto
    {
        public int ExampleModelId { get; set; }
		public string Title { get; set; }
		public string Brief { get; set; }
		public string Content { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string ProfileUrl { get; set; }
		public long IDNumber { get; set; }
		public decimal Amount { get; set; }
		public decimal Price { get; set; }
		public int PostalCode { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime StartHijriDate { get; set; }
		public DateTime EndHijriDate { get; set; }
		public int? ExampleCategoryId { get; set; }
		public string ExampleCategoryName { get; set; }
		public int? ExampleStatusId { get; set; }
		public string ExampleStatusName { get; set; }
		public bool IsPublished { get; set; }
		public DateTime PublishingDate { get; set; }
		public string PublishedBy { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class ExampleModelFilter
    {
        public string Title { get; set; }
		public int? ExampleCategoryId { get; set; }
		public int? ExampleStatusId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class ExampleModelDtoInsertValidator : AbstractValidator<ExampleModelDto>
    {
        public ExampleModelDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.TitleAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["ExampleModel_TitleAr"]);

			RuleFor(x => x.TitleEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["ExampleModel_TitleEn"]);

			RuleFor(x => x.BriefAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,250).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "250"))
			    .WithName(modulesLocalizer["ExampleModel_BriefAr"]);

			RuleFor(x => x.BriefEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,250).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "250"))
			    .WithName(modulesLocalizer["ExampleModel_BriefEn"]);

			RuleFor(x => x.ContentAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_ContentAr"]);

			RuleFor(x => x.ContentEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_ContentEn"]);

			RuleFor(x => x.FirstName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ExampleModel_FirstName"]);

			RuleFor(x => x.LastName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ExampleModel_LastName"]);

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "100"))
			    .Matches(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ExampleModel_Email"]);

			RuleFor(x => x.Phone)
			    .Length(8,20).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "8").Replace("{MaxLength}", "20"))
			    .Matches(@"^\d+$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ExampleModel_Phone"]);

			RuleFor(x => x.Mobile)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,12).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "12"))
			    .Matches(@"^(\+?966|0)?5\d{8}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ExampleModel_Mobile"]);

			RuleFor(x => x.ProfileUrl)
			    .MaximumLength(150).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "150"))
			    .WithName(modulesLocalizer["ExampleModel_ProfileUrl"]);

			RuleFor(x => x.IDNumber)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_IDNumber"]);

			RuleFor(x => x.Amount)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_Amount"]);

			RuleFor(x => x.Price)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_Price"]);

			RuleFor(x => x.PostalCode)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_PostalCode"]);

			RuleFor(x => x.Address)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,150).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "150"))
			    .WithName(modulesLocalizer["ExampleModel_Address"]);

			RuleFor(x => x.Website)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,150).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "150"))
			    .Matches(@"^https://[^\s/$.?#].[^\s]*$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ExampleModel_Website"]);

			RuleFor(x => x.StartDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_StartDate"]);

			RuleFor(x => x.EndDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_EndDate"]);

			RuleFor(x => x.StartHijriDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_StartHijriDate"]);

			RuleFor(x => x.EndHijriDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_EndHijriDate"]);

			RuleFor(x => x.IsPublished)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_IsPublished"]);

			RuleFor(x => x.PublishingDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_PublishingDate"]);

			RuleFor(x => x.PublishedBy)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName(modulesLocalizer["ExampleModel_PublishedBy"]);


        }
    }
    
    public class ExampleModelDtoUpdateValidator : ExampleModelDtoInsertValidator
    {
        public ExampleModelDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.ExampleModelId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ExampleModel_ExampleModelId"]);


        }
    }
    
    public class ExampleModelFilterValidator : AbstractValidator<ExampleModelFilter>
    {
        public ExampleModelFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Title)
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["ExampleModel_TitleAr"]);


        }
    }
}
