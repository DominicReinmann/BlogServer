using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Manager.CommentManagement
{
    public class CommentManager : ICommentManager
    {
        private readonly DbManager<Comments> _commentManager;

        public CommentManager(DbManager<Comments> commentManager)
        {
            _commentManager = commentManager;
        }

        public void AddComment(Comments comment)
        {
            _commentManager.Add(comment);
        }

        public void UpdateComment(Comments comment)
        {
            _commentManager.Update(comment);
        }

        public void DeleteComment(Comments comment)
        {
            _commentManager.Delete(comment);
        }

        public IQueryable<Comments> GetAll()
        {
            return _commentManager.GetAll();
        }
    }
}
