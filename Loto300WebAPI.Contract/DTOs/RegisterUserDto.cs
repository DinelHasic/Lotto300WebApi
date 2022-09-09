using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Contract.DTOs
{
    public class RegisterUserDto
    {
        [StringLength(12,MinimumLength = 3,ErrorMessage = "First Name has to contain at least 3 characters in length")]
        public string FirstName { get; set; }

        [StringLength(12, MinimumLength = 3,ErrorMessage = "Last Name has to contain at least 2 characters in length")]
        public string LastName { get; set; }

    
        [StringLength(12, MinimumLength = 5, ErrorMessage = "UserName has to contain at least 5 characters in length")]
        public string UserName { get; set; }

      
        [StringLength(32, MinimumLength = 7,ErrorMessage = "Password has to contain at least 7 characters in length")]
        [DataType(DataType.Password)]
        [PasswordValidation(ErrorMessage = "Password has to contain at least one number and upercase letter")]
        public string Password { get; set; }
    }
}
