using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Workflows.PostWorkflows
{
    public interface IPostWorkflow
    {
        void RunDeletePost(Posts post);
        void RunEditPost(Posts post);
        List<Posts> RunGetPost(int id);
        void RunSavePost(Posts post);
    }
}