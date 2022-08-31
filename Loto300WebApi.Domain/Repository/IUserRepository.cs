using Loto300WebApi.Domain.Entites;

namespace Loto3000App.Models.Repository
{
    public interface IUserRepository
    {
        public IReadOnlyCollection<User> GetUsers();

        public User FindUserById(int id);

        int GenerateId();

        Task AddUser(User user);

        User FindUserByUserName(string userName);
    }
}
