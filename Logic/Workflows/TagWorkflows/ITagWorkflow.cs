using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Workflows.TagWorkflows
{
    public interface ITagWorkflow
    {
        List<Tag> RunGetTags();
    }
}