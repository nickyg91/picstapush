using System;
using System.ComponentModel.DataAnnotations;

namespace Picstapush.Web.Validators
{
    public class PropertyHasSameValueAttribute : ValidationAttribute
    {
        private readonly string _propertyToCompare;

        public PropertyHasSameValueAttribute(string property)
        {
            _propertyToCompare = property;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var property = validationContext.ObjectType.GetProperty(_propertyToCompare);

            if (property == null)
            {
                throw new ArgumentException($"Property {_propertyToCompare} not found on object.");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);
            if (comparisonValue?.GetType() != typeof(string))
            {
                throw new ArgumentException("Property must be of type string.");
            }
            if ((string)comparisonValue == (string)value)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
