using Loto300WebApi.Domain.Entites;

namespace Loto3000App.Models
{
    public class Price : BaseEntity
    {

        public  string  Name { get; set; }

        public int  NumberBalls { get; set; }


        public Price(int id,string name, int numberBalls)
        {
            Name = name;
            NumberBalls = numberBalls;
            Id = id;
        }
    }
}
