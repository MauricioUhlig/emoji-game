using uhlig.game.domain.Util;
namespace uhlig.game.domain.Entities
{
    public class RoomEntity
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public bool IsPublic { get; private set; }

        public RoomEntity(bool isPublic, byte codeLength = 4)
        {
            Id = Guid.NewGuid();

            IsPublic = isPublic;
            
            Code = NewCode(codeLength);
        }

        private string NewCode(byte codeLength)
        {
            var code = string.Empty;
            for (int i = 0; i < codeLength; i++)
            {
                code += Characters.GetRandonChar();
            }
            return code;
        }
    }
}