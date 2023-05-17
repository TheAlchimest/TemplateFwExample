using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TemplateFwExample.Shared.ValidationAttributes
{
    public class DisallowHtmlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var tagWithoutClosingRegex = new Regex(@"<[^>]+>");

            var hasTags = tagWithoutClosingRegex.IsMatch(value.ToString());

            if (!hasTags)
                return ValidationResult.Success;

            return new ValidationResult("The field cannot contain html tags");
        }
    }
}
