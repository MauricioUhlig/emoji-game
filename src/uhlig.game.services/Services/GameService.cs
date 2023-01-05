using uhlig.game.domain.Entities;
using uhlig.game.domain.Interfaces.Repositories;
using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Game.Request;
using uhlig.game.domain.ViewModels.Game.Response;

namespace uhlig.game.services.Services
{
    public class GameService : IGameService
    {
        private readonly IBaseRepository<RoomEntity> _roomRepository;
        private readonly IBaseRepository<PlayerEntity> _playerRepository;

        public GameService(
            IBaseRepository<RoomEntity> roomRepository,
            IBaseRepository<PlayerEntity> playerRepository)
        {
            _roomRepository = roomRepository;
            _playerRepository = playerRepository;
        }

        public NewGameResponseViewModel JoinGame(JoinRoomRequestViewModel joinRoom)
        {
            //var room = _roomRepository.GetByExpression(x => x.Code = joinRoom.RoomCode);

            var room = _roomRepository.GetAll()?.FirstOrDefault();

            var player = new PlayerEntity(joinRoom.UserName);
            _playerRepository.Insert(player);

            return new NewGameResponseViewModel(room.Id, player.Id, room.Code);
        }

        public NewGameResponseViewModel NewGame(NewGameRequestViewModel newRoom)
        {
            var room = new RoomEntity(false);
            _roomRepository.Insert(room);

            var player = new PlayerEntity(newRoom.UserName);
            _playerRepository.Insert(player);

            return new NewGameResponseViewModel(room.Id, player.Id, room.Code);
        }

        public NewGameResponseViewModel RandomGame(RandomRoomRequestViewModel randomRoom)
        {
            throw new NotImplementedException();
        }
    }
}