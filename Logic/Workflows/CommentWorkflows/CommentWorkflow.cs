using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Manager.CommentManagement;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogServer.Logic.Workflows.CommentWorkflows
{
    public class CommentWorkflow
    {
        private readonly ILog _log;
        private readonly ICommentManager _manager;
        public CommentWorkflow(ILog log, ICommentManager manager)
        {
            _log = log;
            _manager = manager;
        }

        public void RunPostComment(string comment)
        {
            try
            {
                _manager.AddComment(JsonSerializer.Deserialize<Comments>(comment));
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error adding comment {ex.Message}");
            }
        }

        public void RunEditComment()
        {

        }

        public void RunDeleteComment()
        {

        }
    }
}
