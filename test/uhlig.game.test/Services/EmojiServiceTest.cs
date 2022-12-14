using uhlig.game.domain.Interfaces.Services;

namespace uhlig.game.test.Service;

public class EmojiServiceTest
{
    private readonly IEmojiService _emojiService;
    public EmojiServiceTest(IEmojiService emojiService)
    {
        _emojiService = emojiService;
    }
    [Fact]
    public void TestGetEmojisString()
    {
        // Arrange
        byte size = 4;
        // Act
        var emojis = _emojiService.GetEmojisString(size);
        // Assert 
        Assert.NotNull(emojis);
        Assert.NotEmpty(emojis);
    }
}