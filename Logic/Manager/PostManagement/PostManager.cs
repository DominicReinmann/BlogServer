using BlogServer.CrossCutting.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogServer.Logic.Manager.PostManagement
{
    public class PostManager : IPostManager
    {
        private readonly DbManager<Posts> _postManager;

        public PostManager(DbManager<Posts> postManager)
        {
            _postManager = postManager;
        }

        public void AddPost(Posts post)
        {
            _postManager.Add(post);
        }

        public void UpdatePost(Posts post)
        {
            _postManager.Update(post);
        }

        public void DeletePost(Posts post)
        {
            _postManager.Delete(post);
        }

        public IQueryable<Posts> GetAll()
        {
            return _postManager.GetAll();
        }

        public IQueryable<Posts> GetPostsWithComments(int id)
        {
            return _postManager.GetAll()
                .Where(p => p.Id == id)
                .Include(p => p.Comments);
        }
    }
}
