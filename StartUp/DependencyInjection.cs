using BlogServer.Authentication;
using BlogServer.CrossCutting.Logger;
using BlogServer.Logic.Database;
using BlogServer.Logic.Encryption;
using BlogServer.Logic.Manager.CommentManagement;
using BlogServer.Logic.Manager.ConfigurationManagement;
using BlogServer.Logic.Manager.PostManagement;
using BlogServer.Logic.Manager.TagManagement;
using BlogServer.Logic.Manager.UserManagement;
using BlogServer.Logic.Workflows.CommentWorkflows;
using BlogServer.Logic.Workflows.LoginWorkflows;
using BlogServer.Logic.Workflows.PostWorkflows;
using BlogServer.Logic.Workflows.TagWorkflows;
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
            // Div
            _builder.Services.AddTransient<ILog, Log>();
            _builder.Services.AddTransient<IEncryptionService, EncryptionService>();

            // Workflows
            
            // Login
            _builder.Services.AddTransient<ILoginWorkflow, LoginWorkflow>();
            
            // User
            _builder.Services.AddTransient<IUserManager, UserManager>();
            
            // Comment
            _builder.Services.AddTransient<ICommentWorkflow, CommentWorkflow>();
            _builder.Services.AddTransient<ICommentManager, CommentManager>();
            
            // Post
            _builder.Services.AddTransient<IPostWorkflow, PostWorkflow>();
            _builder.Services.AddTransient<IPostManager,  PostManager>();
            
            // Tags
            _builder.Services.AddTransient<ITagWorkflow, TagWorkflow>();
            _builder.Services.AddTransient<ITagManager, TagManager>();

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
