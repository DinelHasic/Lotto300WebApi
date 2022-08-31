
using Loto3000App.Models;
using Loto3000App.Models.Repository;
using Loto3000App.Storage.Database;
using Loto300WebApi.Domain.Entites;
using Loto300WebAPI.Storage;
using Loto300WebAPI.Storage.Repository;

namespace Loto3000App.Storage.Repository
{
    public class UserRepository : ReposiotyBase<User>, IUserRepository
    {
        public UserRepository(ILottoDbContextcs lottoDbContextcs) : base(lottoDbContextcs)
        {
        }

        public User FindUserById(int id)
        {
            return GetById(id).SingleOrDefault();

        }

        public int GenerateId()
        {
            if (GetAll().Count() == 0)
            {
                return 1;
            }

            return GetAll().Max(x => x.Id) + 1;
        }

        public IReadOnlyCollection<User> GetUsers()
        {
           return GetAll().ToArray();
        }

        public User FindUserByUserName(string userName)
        {
           return GetAll().SingleOrDefault(x => x.UserName == userName);
        }

       
        public async Task AddUser(User user)
        {
          InsterEntity(user);
        }
    }
}
