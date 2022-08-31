using Loto3000App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Contract.DTOs
{
    public class WinnerUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> LottoNumber { get; set; }

        public  Price Prize { get; set; }
    }
}
