using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Manager.CommentManagement
{
    public interface ICommentManager
    {
        void AddComment(Comments comment);
        void DeleteComment(Comments comment);
        IQueryable<Comments> GetAll();
        void UpdateComment(Comments comment);
    }
}