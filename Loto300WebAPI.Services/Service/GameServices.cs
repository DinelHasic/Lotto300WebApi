using Loto3000App.Models;
using Loto3000App.Models.Repository;
using Loto3000App.Storage.Database;
using Loto300WebApi.Domain.Entites;
using Loto300WebApi.Domain.Repository;
using Loto300WebAPI.Contract.DTOs;
using Loto300WebAPI.Contract.ServiceInterface;
using Loto300WebAPI.Services.Mapper;
using Loto300WebAPI.Storage.UnitOfWork;

namespace Loto300WebAPI.Services
{
    public class GameServices : IGameServices
    {
        private IUserRepository _userRepository;

        private IPriceRepository _priceRepository;

        private ISessionRepository _sessionReposiotry;

        private ITicketNumberRepository _ticketNumberRepository;

        private IUnitOfWork _unitOfWork;
        public GameServices(IUserRepository userRepository, IPriceRepository priceRepository, ISessionRepository sessionReposiotry,ITicketNumberRepository ticketNumberRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _priceRepository = priceRepository;
            _sessionReposiotry = sessionReposiotry;
            _ticketNumberRepository = ticketNumberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveNumbers(string numbers, int id)
        {
            User user = _userRepository.FindUserById(id);

            TicketNumber ticketNumber = new TicketNumber();

            ticketNumber.UserPlayer = user;
            ticketNumber.Numbers = numbers;

            _ticketNumberRepository.SaveTicket(ticketNumber);

             await _unitOfWork.SaveChangesAsync();
        }

        public async Task SaveDrawnNumbers(string drawnNumbers)
        {
            Session session = new Session();

            session.NumbersDrawn = drawnNumbers;

            _sessionReposiotry.SaveLottoNumbers(session);

            await _unitOfWork.SaveChangesAsync();

            AssignTicketNumberSessionId();
        }


        public async void AssignTicketNumberSessionId()
        {
            List<TicketNumber> ticketNumbers = _ticketNumberRepository.GetTicketWhereSessionIdNull().ToList();

            int sessionId = _sessionReposiotry.GetLastSessionId();

            ticketNumbers.ForEach(ticketNumbers => ticketNumbers.SessionId = sessionId);

             await _unitOfWork.SaveChangesAsync();

        }

        public List<WinnerUserDto> UsersWon()
        {
            List<string> lottoNumbers =  _sessionReposiotry.GetLottoNumber().Split().ToList();

            int sessionId = _sessionReposiotry.GetLastSessionId();

            List<TicketNumber> ticketNumbers = _ticketNumberRepository.GetTicketNumbers(sessionId).ToList();

            List<WinnerUserDto> userDto = new List<WinnerUserDto>();

            foreach (TicketNumber ticketNumber in ticketNumbers)
            {
                List<string> numbersSplit = ticketNumber.Numbers.Split(" ").ToList();

                List<string> numbersEqual =  numbersSplit.Intersect(lottoNumbers).ToList();

                int countNumber = numbersEqual.Count;

                Price price = _priceRepository.GetPrice(countNumber);

                if (price != null)
                {
                    userDto.Add(ticketNumber.UserPlayer.ToWinnerUserDTO(price, numbersSplit));
                }
            }

            DatabaseLoto.TIKETS = new List<TicketNumber>();
            return userDto;
        }
    }
}
