
using Loto3000App.Models;
using Loto3000App.Models.Repository;
using Loto3000App.Storage.Database;
using Loto300WebApi.Domain.Entites;
using Loto300WebAPI.Storage;
using Loto300WebAPI.Storage.Repository;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> FindUserByUserNameAsync(string userName)
        {
           return  await GetAll().SingleOrDefaultAsync(x => x.UserName == userName);
        }

       
        public void AddUser(User user)
        {
          InsterEntity(user);
        }
    }
}
