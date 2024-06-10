using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Manager.TagManagement;
using System.Linq;

namespace BlogServer.Logic.Workflows.TagWorkflows
{
    public class TagWorkflow : ITagWorkflow
    {
        private readonly ILog _log;
        private readonly ITagManager _manager;

        public TagWorkflow(ILog log, ITagManager manager)
        {
            _log = log;
            _manager = manager;
        }

        public List<Tag> RunGetTags()
        {
            return new List<Tag>(_manager.GetAll());
        }
    }
}
