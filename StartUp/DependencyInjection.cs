using BlogServer.Authentication;
using BlogServer.CrossCutting.Logger;
using BlogServer.Logic.Database;
using BlogServer.Logic.Manager.ConfigurationManagement;
using Microsoft.EntityFrameworkCore;

namespace BlogServer.StartUp
{
    public class DependencyInjection 
    {
        private readonly WebApplicationBuilder _builder;
        public DependencyInjection(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void Inject()
        {
            // 
            _builder.Services.AddTransient<ILog, Log>();
            
            // Configuration
            _builder.Services.AddTransient<IConfigManager, ConfigManager>();

            // Authentication 
            _builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();


            // DB 
            _builder.Services.AddDbContext<DbConntent>(options =>
                options.UseSqlServer(_builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);
        }
    }
}
