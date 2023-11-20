using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Shop.ViewModels.ValidationRules
{
    public class AddressValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? address;
            try
            {
                address = value as string;
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, $"Illegal characters or {ex.Message}");
            }

            if (string.IsNullOrWhiteSpace(address)
                || !address.All(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x)))
            {
                return new ValidationResult(false, $"Invalid address");
            }

            return ValidationResult.ValidResult;
        }
    }
}
