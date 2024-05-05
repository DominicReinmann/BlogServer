using BlogServer.CrossCutting.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogServer.Logic.Database
{
    public class DbConntent : DbContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        
        public DbConntent(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            if(string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException("The connection string is null or empty");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
       
        // db sets go here 
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<User> User {  get; set; }
    }
}
