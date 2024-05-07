using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Manager.PostManagement
{
    public interface IPostManager
    {
        void AddPost(Posts post);
        void DeletePost(Posts post);
        IQueryable<Posts> GetAll();
        IQueryable<Posts> GetPostsWithComments(int id);
        void UpdatePost(Posts post);
    }
}