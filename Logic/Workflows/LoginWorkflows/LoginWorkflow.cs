using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Manager.UserManagement;
using System.Text.Json;

namespace BlogServer.Logic.Workflows.LoginWorkflows
{
    public class LoginWorkflow
    {
        private readonly ILog _log;
        private readonly IUserManager _manager;

        public LoginWorkflow(ILog log, IUserManager manager)
        {
            _log = log;
            _manager = manager;
        }

        public void RunRegisterUser(string user)
        {
            try
            {
                _manager.AddUser(JsonSerializer.Deserialize<User>(user));
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error creating user {ex.Message}");
            }
        }

        public void RunLoginUser()
        {

        }

        public void RunResetPassword()
        {

        }
    }
}
