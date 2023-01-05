using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.ViewModels.Round.Request;

namespace uhlig.game.test.Service;

public class RoundServiceTest
{
    private readonly IRoundService _roundService;
    public RoundServiceTest(IRoundService roundService)
    {
        _roundService = roundService;
    }
    [Fact]
    public void TestNewRound()
    {
        // Arrange
        var roomId = Guid.Empty;
        // Act
        var round = _roundService.CreateNewRoundByRoomId(roomId);
        // Assert 
        Assert.NotNull(round);
    }
    [Fact]
    public void TestGetLastRoundByRoomId()
    {
        // Arrange
        var roomId = Guid.Empty;
        // Act
        var round = _roundService.GetLastRoundByRoomId(roomId);
        // Assert 
        Assert.NotNull(round);
        Assert.NotEmpty(round.Emojis);
    }
    [Fact]
    public void TestGetAllRoundsByRoomId()
    {
        // Arrange
        var roomId = Guid.Empty;
        // Act
        var round = _roundService.GetAllRoundsByRoomId(roomId);
        // Assert 
        Assert.NotNull(round);

    }
    [Fact]
    public void TestSubmit()
    {
        // Arrange
        var submit = new NewPhraseRequestViewModel(Guid.Empty, Guid.Empty, "Frase de teste");
        // Act
        var roundPhrase = _roundService.Submit(submit);
        // Assert 
        Assert.NotNull(roundPhrase);

    }
    [Fact]
    public void TestRoundResult()
    {
        // Arrange
        var roomId = Guid.Empty;
        // Act
        var round = _roundService.RoundResult(roomId);
        // Assert 
        Assert.NotNull(round);

    }
}