using uhlig.game.domain.Interfaces.Services;
using uhlig.game.domain.Util;

namespace uhlig.game.services.Services
{
    public class EmojiService : IEmojiService
    {
        public string GetEmojisString(byte emojiCount)
        {
            var emojis = string.Empty;
            for (int i = 0; i < emojiCount; i++)
            {
                emojis = emojis + Emojis.GetRand();
            }
            return emojis;
        }
    }
}