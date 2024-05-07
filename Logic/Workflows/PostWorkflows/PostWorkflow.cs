using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Manager.PostManagement;
using System.Text.Json;

namespace BlogServer.Logic.Workflows.PostWorkflows
{
    public class PostWorkflow : IPostWorkflow
    {
        private readonly ILog _log;
        private readonly IPostManager _manager;

        public PostWorkflow(ILog log, IPostManager manager)
        {
            _log = log;
            _manager = manager;
        }

        public List<Posts> RunGetPost(int id)
        {
            try
            {
                return _manager.GetPostsWithComments(id).ToList();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error getting Post {ex.Message}");
                return new List<Posts>();
            }
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

        public void RunEditPost(Posts post)
        {
            try
            {
                _manager.UpdatePost(post);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error updating Post {ex.Message}");
            }
        }

        public void RunDeletePost(Posts post)
        {
            try
            {
                _manager.DeletePost(post);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error deleting Post {ex.Message}");
            }
        }
    }
}
