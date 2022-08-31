using Loto3000App.Models;
using Loto300WebApi.Domain.Entites;
using Loto300WebApi.Domain.Enum;

namespace Loto3000App.Storage.Database
{
    public static class DatabaseLoto
    {
        public static List<User> USERS = new List<User>()
        {
            new User(1,"Vanja","test1","test1","test1",UserType.PLayer),
            new User(2,"Dinko","test2","test2","test2",UserType.PLayer),
            new User(3,"Monika","test3","test3","test3",UserType.PLayer),
            new User(4,"Jhony","Smith","Jhony123","Jhony123",UserType.Admin)

        };

        public static List<Price> PRICES = new List<Price>()
        {
            new Price(1,"Car",7),
            new Price(2,"Vacation",6),
            new Price(3,"TV",5),
            new Price(4,"100$ Gift Card",4),
            new Price(5,"50$ Gift Card",3)
        };

        public static List<TicketNumber> TIKETS = new List<TicketNumber>();
        
        public static List<Session> LottoSesion = new List<Session>();

        public static int GenearteTikeketsId()
        {
           if(TIKETS.Count == 0)
            {
                return 1;
            }

           return TIKETS.Max(x => x.Id) + 1;
        }

        public static int GenearteSessionId()
        {
            if (LottoSesion.Count == 0)
            {
                return 1;
            }

            return LottoSesion.Max(x => x.Id) + 1;
        }
    }
}
