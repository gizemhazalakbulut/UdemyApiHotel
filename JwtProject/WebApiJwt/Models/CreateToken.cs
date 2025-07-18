using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes= Encoding.UTF8.GetBytes("aspnetcoreapiapi_supersecure_token_2025"); // JWT için kullanılacak anahtar kelimeyi UTF-8 formatında byte dizisine çevirme

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes); // simetrik güvenlik anahtarı oluşturma

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // kimlik doğrulama bilgileri

            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost", audience:"http://localhost", notBefore:DateTime.Now, expires:DateTime.Now.AddSeconds(20), signingCredentials: signingCredentials); // JWT oluşturma

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler(); // JWT işleyici oluşturma
            return handler.WriteToken(token); // JWT'yi yazdırma
        }

        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi_supersecure_token_2025"); // JWT için kullanılacak anahtar kelimeyi UTF-8 formatında byte dizisine çevirme

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes); // simetrik güvenlik anahtarı oluşturma

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // kimlik doğrulama bilgileri

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()), // Kullanıcı kimliği
                new Claim(ClaimTypes.Role, "Admin"), // Kullanıcı rolü
                new Claim(ClaimTypes.Role,"Visitor")
            };


            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(30), signingCredentials: signingCredentials,claims:claims); // JWT oluşturma

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler(); // JWT işleyici oluşturma
            return handler.WriteToken(token); // JWT'yi yazdırma
        }
    }
}
