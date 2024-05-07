using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Workflows.CommentWorkflows
{
    public interface ICommentWorkflow
    {
        void RunDeleteComment(Comments comment);
        void RunEditComment(Comments comment);
        void RunPostComment(string comment);
    }
}