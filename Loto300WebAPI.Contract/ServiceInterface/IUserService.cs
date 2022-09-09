using Loto3000App.Models;
using Loto300WebAPI.Contract.DTOs;
using Lotto300WebAPI.Shared;

namespace Loto3000App.ServiceInterface
{
    public interface IUserService
    {
        IReadOnlyCollection<UserInfoDto> GetAllUsers();

        UserInfoDto GetUserById(int id);

        Task<UserInfoDto> GetUseByUserNameAsync(string userName);

        Task AddNewUserAsync(RegisterUserDto newUser);

        Task<Token> GetUseByUserNameAndPasswordAsync(LoginUserCredentialsDto user);
    }
}
