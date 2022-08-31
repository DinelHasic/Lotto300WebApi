using Loto3000App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebApi.Domain.Entites
{
    public class TicketNumber : BaseEntity
    {
        public  string  Numbers { get; set; }

        public int NubersId { get; set; }

        public User  UserPlayer { get; set; }
    }
}
