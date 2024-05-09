using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Database;
using Microsoft.EntityFrameworkCore;

namespace BlogServer.Logic.Manager.CommentManagement
{
    public class CommentManager : ICommentManager
    {
        private readonly DbManager<Comments> _commentManager;

        public CommentManager(DbConntent context)
        {
            _commentManager = new DbManager<Comments>(context);
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
