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
        var roomId = new Guid("b5212d38-9600-47c6-a5ab-8a7e7d2b3421");
        // Act
        var round = _roundService.CreateNewRoundByRoomId(roomId);
        // Assert 
        Assert.NotNull(round);
    }
    [Theory]
    [InlineData("b5212d38-9600-47c6-a5ab-8a7e7d2b3421", true)]
    [InlineData("b5212d38-9600-47c6-0000-8a7e7d2b3421", false)]
    public void TestGetLastRoundByRoomId(Guid id, bool exists)
    {
        // Arrange

        // Act
        if (exists)
        {
            var round = _roundService.GetLastRoundByRoomId(id);
            // Assert 
            Assert.NotNull(round);
            Assert.NotEmpty(round.Emojis);
        }
        else
            Assert.Throws<ArgumentNullException>(() => _roundService.GetLastRoundByRoomId(id));
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