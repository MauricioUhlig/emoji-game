using uhlig.game.domain.Entities;
using uhlig.game.domain.Interfaces.Repositories;
using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.Notifications;
using uhlig.game.domain.ViewModels.Game.Request;
using uhlig.game.domain.ViewModels.Game.Response;

namespace uhlig.game.services.Services
{
    public class GameService : IGameService
    {
        private readonly IBaseRepository<RoomEntity> _roomRepository;
        private readonly IBaseRepository<PlayerEntity> _playerRepository;
        private readonly ITokenService _tokenService;
        private readonly DomainNotification _domainNotification;

        public GameService(
            IBaseRepository<RoomEntity> roomRepository,
            IBaseRepository<PlayerEntity> playerRepository,
            ITokenService tokenService,
            DomainNotification domainNotification)
        {
            _roomRepository = roomRepository;
            _playerRepository = playerRepository;
            _tokenService = tokenService;
            _domainNotification = domainNotification;
        }

        public NewGameResponseViewModel? JoinGame(JoinRoomRequestViewModel joinRoom)
        {
            var room = _roomRepository.GetByExpression(x => x.Code == joinRoom.RoomCode)?.FirstOrDefault();

            if (room == null)
            {
                _domainNotification.AddNotification("ER002");
                return null;
            }

            var player = new PlayerEntity(joinRoom.UserName);
            _playerRepository.Insert(player);

            return new NewGameResponseViewModel(room.Id, player.Id, room.Code, GeneratePlayerToke(player));
        }

        public NewGameResponseViewModel NewGame(NewGameRequestViewModel newRoom)
        {
            var room = new RoomEntity(false);
            _roomRepository.Insert(room);


            var player = new PlayerEntity(newRoom.UserName);
            _playerRepository.Insert(player);

            return new NewGameResponseViewModel(room.Id, player.Id, room.Code, GeneratePlayerToke(player));
        }

        public NewGameResponseViewModel? RandomGame(RandomRoomRequestViewModel randomRoom)
        {
            var room = _roomRepository.GetByExpression(x => x.IsPublic == true)?.FirstOrDefault();
            if (room == null)
            {
                _domainNotification.AddNotification("ER003");
                return null;
            }

            var player = new PlayerEntity(randomRoom.UserName);
            _playerRepository.Insert(player);

            return new NewGameResponseViewModel(room.Id, player.Id, room.Code, GeneratePlayerToke(player));
        }

        private string GeneratePlayerToke(PlayerEntity player) => _tokenService.GenerateToken(player, 60);
    }
}