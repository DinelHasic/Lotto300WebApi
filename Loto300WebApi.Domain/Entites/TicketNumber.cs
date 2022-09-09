using Loto3000App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebApi.Domain.Entites
{
    public class TicketNumber : BaseEntity
    {
        public  string  Numbers { get; set; }

        [ForeignKey(nameof(UserId))]
        public User  UserPlayer { get; set; }

        public int UserId { get; set; } 


        [ForeignKey(nameof(SessionId))]
        public Session? Session { get; set; }


        public int? SessionId { get; set; }

    }
}
