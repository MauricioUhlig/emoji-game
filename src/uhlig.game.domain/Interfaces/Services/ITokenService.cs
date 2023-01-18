using uhlig.game.domain.Entities;

namespace uhlig.game.domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(PlayerEntity player, int tempoSessao);
    }
}