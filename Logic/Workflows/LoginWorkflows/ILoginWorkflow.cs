using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Workflows.LoginWorkflows
{
    public interface ILoginWorkflow
    {
        User GetUser(string username);
        bool RunLoginUser(string pw, string username);
        void RunRegisterUser(User user);
        void RunResetPassword(User user);
    }
}