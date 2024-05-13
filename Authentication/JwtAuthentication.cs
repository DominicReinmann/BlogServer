using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogServer.Authentication
{
    public class JwtAuthentication
    {
        private readonly WebApplicationBuilder _builder;
        private string _jwtIssuer, _jwtKey;

        public JwtAuthentication(WebApplicationBuilder builder)
        {
            _builder = builder;
            _jwtIssuer = _builder.Configuration.GetSection("Jsw:Issuer").Get<string>();
            _jwtKey = _builder.Configuration.GetSection("Jwt:Key").Get<string>();
        }

        public void Authenticate()
        {
            _builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = _jwtIssuer,
                         ValidAudience = _jwtIssuer,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey))
                     };
                 });

            _builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });
        }
    }
}
