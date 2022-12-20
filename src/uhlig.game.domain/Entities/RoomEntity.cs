using uhlig.game.domain.Util;
namespace uhlig.game.domain.Entities
{
    public class RoomEntity : BaseEntity
    {
        public string Code { get; private set; }
        public bool IsPublic { get; private set; }

        public RoomEntity(bool isPublic, byte codeLength = 4) : base()
        {
            IsPublic = isPublic;

            Code = NewCode(codeLength);
        }
        public RoomEntity(Guid id, string code, bool isPublic) : base(id)
        {
            Code = code;
            IsPublic = isPublic;
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