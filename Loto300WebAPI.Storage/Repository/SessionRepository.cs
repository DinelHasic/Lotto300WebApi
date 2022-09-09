using Loto300WebApi.Domain.Entites;
using Loto300WebApi.Domain.Repository;

namespace Loto300WebAPI.Storage.Repository
{
    public class SessionRepository : ReposiotyBase<Session>,ISessionRepository
    {
        public SessionRepository(ILottoDbContextcs lottoDbContextcs) : base(lottoDbContextcs)
        {
        }

        public void SaveLottoNumbers(Session session)
        {
            InsterEntity(session);
        }

        public string GetLottoNumber()
        {

            return GetAll().OrderBy(x => x.Id).Last().NumbersDrawn;
        }

        public int GetLastSessionId()
        {
            return GetAll().OrderBy(x => x.Id).Last().Id;
        }

        public int GenearteSessionId()
        {
            if (GetAll().Count() == 0)
            {
                return 1;
            }

            return GetAll().Max(x => x.Id) + 1;
        }
    }
}
