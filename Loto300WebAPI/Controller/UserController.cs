using Loto3000App.Models;
using Loto3000App.ServiceInterface;
using Loto300WebAPI.Contract.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loto300WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("all/users")]
        public ActionResult<IEnumerable<UserInfoDto>> GetAllUsers()
        {
            IEnumerable<UserInfoDto> users = _userServices.GetAllUsers();

            return users.ToArray();
        }


        [HttpGet("all/users/credentials")]
        public ActionResult<IEnumerable<UserCredentials>> GetAllUsersCredinetals()
        {
            IEnumerable<UserCredentials> users = _userServices.GetUsersCredetntials();

            return users.ToArray();
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            UserInfoDto user = _userServices.GetUserById(id);

            return Ok(user);
        }

        [HttpPost("create/user")]
        public  IActionResult CreateNewUser([FromBody] CreateNewUserDto newUser)
        {
           _userServices.AddNewUser(newUser);

            return Ok();
        }
    }
}
