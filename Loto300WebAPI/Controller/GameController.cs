using Loto3000App.Models;
using Loto3000App.ServiceInterface;
using Loto300WebAPI.Contract.DTOs;
using Loto300WebAPI.Contract.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loto3000App.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IUserService _userServices;

        private IGameServices _gameServices;


        public GameController(IUserService userServices, IGameServices gameServices)
        {
            _userServices = userServices;
            _gameServices = gameServices;
        }


        [HttpPost("numbers/selected")]
        public async Task<IActionResult> SelectedNumbersAsync([FromBody] UserLottoNumbers userGet)
        {

            UserInfoDto user =  await _userServices.GetUseByUserNameAsync(userGet.Username);

            if (user is null)
            {
                return NotFound();
            }

            await _gameServices.SaveNumbers(userGet.LottoNumbers, user.Id);

            return Ok(user);
        }


        [HttpGet("winners")]
        public ActionResult<IEnumerable<WinnerUserDto>> GetWinner()
        {

            IEnumerable<WinnerUserDto> winners = _gameServices.UsersWon();

            return Ok(winners);
        }

        [HttpPost("drawn/numbers")]
   /*     [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> DrawnNumbersAsync([FromBody] string numbers)
        {
           await _gameServices.SaveDrawnNumbers(numbers);

            return Ok(numbers);
        }
    }
}
