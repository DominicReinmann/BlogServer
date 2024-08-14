using BlogServer.CrossCutting.Models.Domain;

namespace BlogServer.Logic.Manager.TagManagement
{
    public interface ITagManager
    {
        void AddTag(Tag tag);
        void DeleteTag(Tag tag);
        IQueryable<Tag> GetAll();
        void UpdateTag(Tag tag);
    }
}