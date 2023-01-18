using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using uhlig.game.domain.Entities;
using uhlig.game.domain.Interfaces.Services;

namespace uhlig.game.services.Services
{
    public class TokenService : ITokenService
    {
        public readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(PlayerEntity player, int tempoSessao)
        {
            if (tempoSessao <= 0)
                throw new ArgumentException("O tempo de sessão precisa ser maior que 0 !");

            var tokenHandler = new JwtSecurityTokenHandler();
            var privateKey = _configuration["SecretToken"];

            var key = Encoding.ASCII.GetBytes(privateKey ?? "QLiYhE2RkjEd%67b6fQymMu7^&ncghdZoLoSddAqD5Kt84FEqmLjLh");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Name", player.Name),
                    new Claim("PlayerId", player.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(tempoSessao),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}