using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MongoDBApp.Validators
{
    public class RegexValidationRule : ValidationRule
    {
      
        private string Message = "Incorrect email format, please enter a valid email!";
        Regex Regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

      public override ValidationResult Validate(object value, CultureInfo cultureInfo)
      {
        if(Regex.IsMatch((string)value))
          return ValidationResult.ValidResult;
        else
          return new ValidationResult(false, Message);
      }
    }
}
