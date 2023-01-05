using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Game.Request;

namespace uhlig.game.test.Service;

public class GameServiceTest
{
    private readonly IGameService _gameService;
    public GameServiceTest(IGameService gameService)
    {
        _gameService = gameService;
    }
    [Fact]
    public void TestNewGame()
    {
        // Arrange
        var room = new NewGameRequestViewModel("Mauricio");
        // Act
        var game = _gameService.NewGame(room);
        // Assert 
        Assert.NotNull(game);

    }
    [Theory]
    [InlineData("Mauricio", "code", true)]
    [InlineData("Mauricio", "c404", false)]
    public void TestJoinGame(string name, string code, bool exists)
    {
        // Arrange
        var room = new JoinRoomRequestViewModel(name, code);
        // Act
        if (exists)
        {
            var game = _gameService.JoinGame(room);
            // Assert 
            Assert.NotNull(game);
        }
        else
            Assert.Throws<ArgumentNullException>(() => _gameService.JoinGame(room));
    }
    [Fact]
    public void TestRandomGame()
    {
        // Arrange
        var room = new RandomRoomRequestViewModel("Mauricio");
        // Act
        var game = _gameService.RandomGame(room);
        // Assert 
        Assert.NotNull(game);

    }
}