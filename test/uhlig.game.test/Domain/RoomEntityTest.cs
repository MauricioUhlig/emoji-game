using uhlig.game.domain.Entities;

namespace uhlig.game.test.Domain;
public class RoomEntityTest
{
    [Theory]
    [InlineData(true, 1)]
    [InlineData(true, 6)]
    [InlineData(false, 2)]
    public void TestNewRoomWithCodeLength(bool isPublic, byte codeLength)
    {
        // Arrange
        var room = new RoomEntity(isPublic, codeLength);
        // Act

        // Assert 
        Assert.NotNull(room);
        Assert.Equal(codeLength, room.Code.Length);
        Assert.Equal(isPublic, room.IsPublic);

        Assert.IsType<Guid>(room.Id);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TestNewRoomWithoutCodeLength(bool isPublic)
    {
        // Arrange
        var room = new RoomEntity(isPublic);
        // Act

        // Assert 
        Assert.NotNull(room);
        Assert.Equal(4, room.Code.Length);
        Assert.Equal(isPublic, room.IsPublic);
    }
}