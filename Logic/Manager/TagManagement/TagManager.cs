using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Database;

namespace BlogServer.Logic.Manager.TagManagement
{
    public class TagManager : ITagManager
    {
        private readonly DbManager<Tag> _tagmanager;

        public TagManager(DbConntent context)
        {
            _tagmanager = new DbManager<Tag>(context);
        }

        public IQueryable GetAll()
        {
            return _tagmanager.GetAll();
        }

        public void AddTag(Tag tag)
        {
            _tagmanager.Add(tag);
        }

        public void UpdateTag(Tag tag)
        {
            _tagmanager.Update(tag);
        }

        public void DeleteTag(Tag tag)
        {
            _tagmanager.Delete(tag);
        }
    }
}
