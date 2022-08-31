using Loto300WebAPI.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto300WebAPI.Contract.ServiceInterface
{
    public interface IGameServices
    {
        Task SaveNumbers(string numbers, int id);

        List<WinnerUserDto> UsersWon();

        Task SaveDrawnNumbers(string drawnNumbers);
    }
}
