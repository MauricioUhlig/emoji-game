using uhlig.game.domain.Entities;

namespace uhlig.game.test.Domain;
public class RoundEntityTest
{
    [Theory]
    [InlineData(true, 1)]
    [InlineData(true, 6)]
    [InlineData(false, 2)]
    public void TestNewRound(bool isPublic, byte codeLength)
    {
        // Arrange
        var room = new RoomEntity(isPublic, codeLength);
        var round = new RoundEntity(room.Id, "emojis", 60);
        // Act

        // Assert 
        Assert.NotNull(round);
        Assert.Equal(60, round.TotalSeconds);
        Assert.True (round.StartAt <= DateTime.Now);

        Assert.IsType<Guid>(round.Id);
    }

   
}