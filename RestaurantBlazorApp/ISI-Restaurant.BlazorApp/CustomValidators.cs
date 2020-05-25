using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISI_Restaurant.BlazorApp
{
    public class CustomValidators
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
        public abstract class ConditionalValidationAttribute : ValidationAttribute
        {
            protected readonly ValidationAttribute InnerAttribute;
            public string DependentProperty { get; set; }
            public object TargetValue { get; set; }
            protected abstract string ValidationName { get; }

            protected virtual IDictionary<string, object> GetExtraValidationParameters()
            {
                return new Dictionary<string, object>();
            }

            protected ConditionalValidationAttribute(ValidationAttribute innerAttribute, string dependentProperty, object targetValue)
                => (InnerAttribute, DependentProperty, TargetValue) = (innerAttribute, dependentProperty, targetValue);

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                // get a reference to the property this validation depends upon    
                var containerType = validationContext.ObjectInstance.GetType();
                var field = containerType.GetProperty(this.DependentProperty);
                if (field != null)
                {
                    // get the value of the dependent property    
                    var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);

                    // compare the value against the target value    
                    if ((dependentvalue == null && this.TargetValue == null) || (dependentvalue != null && dependentvalue.Equals(this.TargetValue)))
                    {
                        // match => means we should try validating this field    
                        if (!InnerAttribute.IsValid(value))
                        {
                            // validation failed - return an error    
                            return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
                        }
                    }
                }
                return ValidationResult.Success;
            }
        }
        public class RequiredIfAttribute : ConditionalValidationAttribute
        {
            protected override string ValidationName => "requiredif";
            public RequiredIfAttribute(string dependentProperty, object targetValue)
                : base(new RequiredAttribute(), dependentProperty, targetValue)
            {
            }
            protected override IDictionary<string, object> GetExtraValidationParameters()
                => new Dictionary<string, object>
                {
                    { "rule", "required" }
                };
        }
        public class RangeIfAttribute : ConditionalValidationAttribute
        {
            private readonly int minimum;
            private readonly int maximum;
            protected override string ValidationName => "rangeif";
            public RangeIfAttribute(int minimum, int maximum, string dependentProperty, object targetValue)
                : base(new RangeAttribute(minimum, maximum), dependentProperty, targetValue)
            {
                this.minimum = minimum;
                this.maximum = maximum;
            }
            protected override IDictionary<string, object> GetExtraValidationParameters() =>
                // Set the rule Range and the rule param [minumum,maximum]    
                new Dictionary<string, object>
                {
                    {"rule", "range"},
                    { "ruleparam", $"[{minimum},{maximum}]" }
                };
        }
    }
}
