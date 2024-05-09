using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Database;

namespace BlogServer.Logic.Manager.UserManagement
{
    public class UserManager : IUserManager
    {
        private readonly DbManager<User> _userManager;

        public UserManager(DbConntent context )
        {
            _userManager = new DbManager<User>(context);
        }

        public void AddUser(User user)
        {
            _userManager.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userManager.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userManager.Delete(user);
        }

        public IQueryable<User> GetAll()
        {
            return _userManager.GetAll();
        }
    }
}
