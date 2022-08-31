using Loto3000App.Models;
using Loto3000App.Storage.Database;
using Loto300WebApi.Domain.Repository;

namespace Loto300WebAPI.Storage.Repository
{
    public class PriceRepository : ReposiotyBase<Price>, IPriceRepository
    {
        public PriceRepository(ILottoDbContextcs lottoDbContextcs) : base(lottoDbContextcs)
        {
        }

        public IReadOnlyList<Price> GetAllPrice()
        {
           return GetAll().ToArray();
        }

        public Price GetPrice(int number)
        {
            return GetAll().SingleOrDefault(x => x.NumberBalls == number);
        }
    }
}
