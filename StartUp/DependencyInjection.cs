using BlogServer.CrossCutting.Logger;
using BlogServer.Logic.Manager.ConfigurationManagement;

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
        }
    }
}
