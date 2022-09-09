using Loto3000App.Models;
using Loto300WebAPI.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Services.Mapper
{
    internal static class UserMapper
    {
        public static WinnerUserDto ToWinnerUserDTO(this  User user,Price price,List<string> lottonumbers)
        {
            return new WinnerUserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Prize = price,
                LottoNumber = lottonumbers
            };
        }


        public static UserInfoDto ToUserInfoDto(this User user)
        {
            return new UserInfoDto()
            {
                Id = user.Id,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
            };
        }

        public static LoginUserCredentialsDto ToUserCredentials(this User user)
        {
            return new LoginUserCredentialsDto()
            {
                UserName = user.UserName,
                Password = user.Password,
            };
        }
    }
}
