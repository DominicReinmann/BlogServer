using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Manager.UserManagement
{
    public interface IUserManager
    {
        void AddUser(User user);
        void DeleteUser(User user);
        IQueryable<User> GetAll();
        void UpdateUser(User user);
    }
}