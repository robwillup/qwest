using System;
using System.ComponentModel.DataAnnotations;

namespace Quest.Validators
{
    class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                throw new Exception("cannot be null");
            return ValidationResult.Success;
        }
    }
}
