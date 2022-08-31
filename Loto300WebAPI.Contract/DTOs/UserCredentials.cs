using Loto300WebApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Contract.DTOs
{
    public class UserCredentials
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
