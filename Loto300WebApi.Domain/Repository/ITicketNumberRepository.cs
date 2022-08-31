using Loto300WebApi.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebApi.Domain.Repository
{
    public interface ITicketNumberRepository
    {
        void SaveTicket(TicketNumber ticketNumber);

        public int GenerateTicketId();

        IReadOnlyCollection<TicketNumber> GetTicketNumbers();
    }
}

