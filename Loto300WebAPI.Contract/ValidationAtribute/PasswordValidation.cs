using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Contract
{
    public class PasswordValidation : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            string? password = value?.ToString();

            bool isUpper = password.Any(x =>  char.IsDigit(x)) && password.Any(x => char.IsUpper(x));

    
            return isUpper;
        }
    }
}
