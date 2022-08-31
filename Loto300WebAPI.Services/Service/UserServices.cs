using Loto3000App.Models;
using Loto3000App.Models.Repository;
using Loto3000App.ServiceInterface;
using Loto300WebAPI.Contract.DTOs;
using Loto300WebAPI.Services.Mapper;
using Loto300WebAPI.Storage.UnitOfWork;

namespace Loto3000App.Service
{

    public class UserServices : IUserService
    {
        private IUserRepository _userRepository;

        private IUnitOfWork _unitOfWork;

        public UserServices(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public UserInfoDto GetUserById(int id)
        {
           User user =  _userRepository.FindUserById(id);

           return user.ToUserInfoDto();
        }

        public UserInfoDto GetUseByUserName(string userName)
        {
           User user  = _userRepository.FindUserByUserName(userName);

            return user.ToUserInfoDto();
        }

        public IReadOnlyCollection<UserInfoDto> GetAllUsers()
        {
            return _userRepository.GetUsers().Select(x => x.ToUserInfoDto()).ToArray();

        }
        public IReadOnlyCollection<UserCredentials> GetUsersCredetntials()
        {
            return _userRepository.GetUsers().Select(x => x.ToUserCredentials()).ToArray();

        }
        public async Task AddNewUser(CreateNewUserDto newUser)
        {
            User user = new User();

            user.Id = _userRepository.GenerateId();
            user.UserName = newUser.UserName;
            user.Password = newUser.Password;  
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.UserType = 0;

            _userRepository.AddUser(user);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
