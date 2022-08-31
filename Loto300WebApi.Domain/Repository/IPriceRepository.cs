using Loto3000App.Models;

namespace Loto300WebApi.Domain.Repository
{ 
    public interface IPriceRepository
    {
        IReadOnlyList<Price> GetAllPrice();

        Price GetPrice(int number);
    }
}
