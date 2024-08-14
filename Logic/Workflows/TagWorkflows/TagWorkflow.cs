using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Manager.TagManagement;

namespace BlogServer.Logic.Workflows.TagWorkflows
{
    public class TagWorkflow : ITagWorkflow
    {
        private readonly ITagManager _manager;
        private readonly ILog _log;

        public TagWorkflow(ITagManager manager, ILog log)
        {
            _manager = manager;
            _log = log;
        }

        public IQueryable<Tag> RunGetTags()
        {
            try
            {
                return (IQueryable<Tag>)_manager.GetAll();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error getting Post {ex.Message}");
                return null;
            }
        }
    }
}