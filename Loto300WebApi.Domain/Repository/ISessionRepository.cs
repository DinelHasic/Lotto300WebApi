using Loto300WebApi.Domain.Entites;

namespace Loto300WebApi.Domain.Repository
{
    public interface ISessionRepository
    {
        void SaveLottoNumbers(Session session);

        public int GenearteSessionId();

        string GetLottoNumber();
    }
}
