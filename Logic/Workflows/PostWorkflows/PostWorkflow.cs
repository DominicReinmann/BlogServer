using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Manager.PostManagement;
using System.Text.Json;

namespace BlogServer.Logic.Workflows.PostWorkflows
{
    public class PostWorkflow
    {
        private readonly ILog _log;
        private readonly IPostManager _manager;

        public PostWorkflow(ILog log, IPostManager manager)
        {
            _log = log;
            _manager = manager;
        }

        public void RunGetPost()
        {

        }

        public void RunSavePost(string post)
        {
            try
            {
                _manager.AddPost(JsonSerializer.Deserialize<Posts>(post));
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error adding Post {ex.Message}");
            }
        }

        public void RunEditPost()
        {

        }
    }
}
