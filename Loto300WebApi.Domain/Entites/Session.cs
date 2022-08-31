namespace Loto300WebApi.Domain.Entites
{
    public class Session : BaseEntity
    {
        public string NumbersDrawn { get; set; }

        public DateTime Created { get; set; }


        public Session()
        {
            Created = DateTime.Now;
        }
    }
}
