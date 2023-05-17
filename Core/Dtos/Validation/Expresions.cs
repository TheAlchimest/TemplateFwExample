using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TemplateFwExample.Dtos.Validation
{
    public class ArabicAttribute : ValidationAttribute
    {
        public ArabicAttribute() : base()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value?.ToString()))
                return ValidationResult.Success;

            var isValidUsername = new Regex(@"^[\u0621-\u064A\u0660-\u06690-9$@$!%*?&#^-_,""“\n +]*$").IsMatch(value.ToString());
            if (isValidUsername == false)
                return new ValidationResult("Arabic Text only");

            return ValidationResult.Success;
        }
    }

    public class EnglishAttribute : ValidationAttribute
    {
        public EnglishAttribute() : base()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value?.ToString()))
                return ValidationResult.Success;

            var isValidUsername = new Regex(@"^[a-zA-Z0-9$@$!%*?&#^-_,\r\n\\/ +]+$").IsMatch(value.ToString());
            if (isValidUsername == false)
                return new ValidationResult("English Text only");

            return ValidationResult.Success;
        }
    }

    public class EnumRangeAttribute : ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public EnumRangeAttribute(int min, int max) : base()
        {
            Min = min;
            Max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value?.ToString()))
                return ValidationResult.Success;

            var enumValue = Convert.ToInt32(value);
            if (Min <= enumValue && enumValue <= Max)
                return ValidationResult.Success;

            return new ValidationResult("Enum not correct");
        }
    }

    public class UniquenessArrayAttribute : ValidationAttribute
    {
        public UniquenessArrayAttribute() : base()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value?.ToString()))
                return ValidationResult.Success;

            var input = (List<Int64>)value;
            var hasDuplicates = false;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[i] == input[j])
                    {
                        hasDuplicates = true;
                        break;
                    }
                }
                if (hasDuplicates)
                    break;
            }

            if (hasDuplicates)
                return new ValidationResult("Array has dublicated numbers");

            return ValidationResult.Success;
        }
    }
}
