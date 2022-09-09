using Loto3000App.Models;
using Loto3000App.ServiceInterface;
using Loto300WebAPI.Contract.DTOs;
using Lotto300WebAPI.Shared;
using Microsoft.AspNetCore.Authorization;
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

            return Ok(users.ToArray());
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            UserInfoDto user = _userServices.GetUserById(id);

            return Ok(user);
        }

        [HttpPost("create/user")]
        public  async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserDto newUser)
        {
            await  _userServices.AddNewUserAsync(newUser);

            return Ok(newUser);
        }

        [HttpPost("login/user")]
        public async Task<ActionResult<Token>> LogInUser([FromBody] LoginUserCredentialsDto user)
        {
            Token data = null;

            try
            {
                data = await _userServices.GetUseByUserNameAndPasswordAsync(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(data);
        }
    }
}
