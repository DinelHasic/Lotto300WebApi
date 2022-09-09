using Loto300WebApi.Domain.Entites;
using Loto300WebApi.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Storage.Repository
{
    public class TicketNumberRepository : ReposiotyBase<TicketNumber>, ITicketNumberRepository
    {
        public TicketNumberRepository(ILottoDbContextcs lottoDbContextcs) : base(lottoDbContextcs)
        {

        }

        public void SaveTicket(TicketNumber ticketNumber)
        {
            InsterEntity(ticketNumber);
        }

        public IReadOnlyCollection<TicketNumber> GetTicketNumbers(int sessionId)
        {
            return GetAll().Where(x => x.SessionId == sessionId).Include(x => x.UserPlayer).ToArray();
        }


        public IReadOnlyCollection<TicketNumber> GetTicketWhereSessionIdNull()
        {
            return GetAll().Where(x => x.SessionId == null).ToArray();
        }

        public int GenerateTicketId()
        {
            if(GetAll().Count() == 0)
            {
                return 1;
            }

            return GetAll().Max(x => x.Id) + 1;
        }
    }
}
