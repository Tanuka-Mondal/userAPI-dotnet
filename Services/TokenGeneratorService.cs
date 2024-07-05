using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserAPI_Tanuka.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(int id, string? name, string? role)
        {
            var userClaims = new[] { 
                new Claim(JwtRegisteredClaimNames.UniqueName, $"{id.ToString()}"),
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(ClaimTypes.Role,$"{role}"),
                new Claim(ClaimTypes.Name,$"{name}")
            };

            string secretKey = "cuhgauhiuhujnbjhnailjpihydrses35dyihijondssooqwqwwqbkbhjijuogywadcthniahihuvuahbiahs";
            byte[] userSecretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(userSecretKeyInBytes);
            var userSignInCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "UserApi",
                audience: "BicycleApi",
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: userSignInCredentials,
                claims: userClaims
                );
            var userTokenHandler = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                userRole=role
            };
            string userToken = JsonConvert.SerializeObject(userTokenHandler);
            return $"{userToken}";
        }
    }
}
