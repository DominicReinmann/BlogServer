using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Manager.UserManagement
{
    public class UserManager : IUserManager
    {
        private readonly DbManager<User> _userManager;

        public UserManager(DbManager<User> userManager)
        {
            _userManager = userManager;
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
