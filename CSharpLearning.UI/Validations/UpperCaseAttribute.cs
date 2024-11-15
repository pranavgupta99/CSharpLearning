using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.Validations
{
    public class UpperCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                if (!string.IsNullOrEmpty(stringValue))
                {
                    char firstChar = stringValue[0];
                    if(char.IsUpper(firstChar))
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "The First Letter must be in upper Case");
        }
    }
}
