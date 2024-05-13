using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Workflows.CommentWorkflows
{
    public interface ICommentWorkflow
    {
        void RunDeleteComment(int id);
        void RunEditComment(Comments comment);
        void RunPostComment(Comments comment);
    }
}