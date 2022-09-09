using Loto3000App.Models;
using Loto3000App.Models.Repository;
using Loto3000App.ServiceInterface;
using Loto300WebApi.Domain.Enum;
using Loto300WebAPI.Contract.DTOs;
using Loto300WebAPI.Services.Extension;
using Loto300WebAPI.Services.Mapper;
using Loto300WebAPI.Storage.UnitOfWork;
using Lotto300WebAPI.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace Loto3000App.Service
{

    public class UserServices : IUserService
    {
        private IUserRepository _userRepository;

        private IUnitOfWork _unitOfWork;

        private IOptions<Auth> _options;

        public UserServices(IUserRepository userRepository, IUnitOfWork unitOfWork, IOptions<Auth> options)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public UserInfoDto GetUserById(int id)
        {
            User user = _userRepository.FindUserById(id);

            return user.ToUserInfoDto();
        }

        public async Task<UserInfoDto> GetUseByUserNameAsync(string userName)
        {
            User user = await _userRepository.FindUserByUserNameAsync(userName);

            return user.ToUserInfoDto();
        }

        public IReadOnlyCollection<UserInfoDto> GetAllUsers()
        {
            return _userRepository.GetUsers().Select(x => x.ToUserInfoDto()).ToArray();

        }

        public async Task AddNewUserAsync(RegisterUserDto newUser)
        {

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            //get the bytes from the password string
            byte[] passwordBytes = Encoding.ASCII.GetBytes(newUser.Password);
            //get the hash
            byte[] passwordHash = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            //get the string hash
            string hashedPasword = Encoding.ASCII.GetString(passwordHash);


            User user = new User();

            user.UserName = newUser.UserName;
            user.Password = hashedPasword;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.UserType = UserType.PLayer;

            _userRepository.AddUser(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Token> GetUseByUserNameAndPasswordAsync(LoginUserCredentialsDto user)
        {

            User getUser = await _userRepository.FindUserByUserNameAsync(user.UserName);

            if (getUser == null)
            {
                throw new Exception("Username not found");
            }

            string hashedPassword = user.Password.PasswordHashed();

            if (hashedPassword != getUser.Password)
            {
                throw new Exception("Password not found");
            }

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2), // the token will be valid for two hours
                //signature configuration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature),
                //payload
                Subject = new ClaimsIdentity(
                    new[]
                   {
                        new Claim(ClaimTypes.Name, getUser.UserName),
                        new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
                        new Claim(ClaimTypes.Role, getUser.UserType.ToString())
                    }
                )
            };
            //generate token with the configuration
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            //convert it to string

            Token tokenData = new Token();

            tokenData.Data = jwtSecurityTokenHandler.WriteToken(token);

            tokenData.Type = getUser.UserType;

            return tokenData;


        }
    }
}
