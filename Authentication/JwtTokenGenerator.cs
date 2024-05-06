using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Encodings;

namespace BlogServer.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _config;

        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_config["Jsw:Issuer"], _config["Jwt:Issuer"], null
                , expires: DateTime.Now.AddMinutes(120)
                , signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
