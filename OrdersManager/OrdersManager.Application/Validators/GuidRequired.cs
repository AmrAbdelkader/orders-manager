using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdersManager.Application.Validators
{
    public class GuidRequired : ValidationAttribute
    {
        public GuidRequired(string Message)
        {
            ErrorMessage = Message;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Guid movie = (Guid)validationContext.ObjectInstance;
            

            if (movie == Guid.Empty)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
