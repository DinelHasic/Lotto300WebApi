using Loto3000App.Models;
using Loto300WebAPI.Contract.DTOs;

namespace Loto3000App.ServiceInterface
{
    public interface IUserService
    {
        IReadOnlyCollection<UserInfoDto> GetAllUsers();

        UserInfoDto GetUserById(int id);

        UserInfoDto GetUseByUserName(string userName);

        IReadOnlyCollection<UserCredentials> GetUsersCredetntials(); 

        Task AddNewUser(CreateNewUserDto newUser);
    }
}
