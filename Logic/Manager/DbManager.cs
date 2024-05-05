using BlogServer.Logic.Database;
using Microsoft.EntityFrameworkCore;

namespace BlogServer.Logic.Manager
{
    public class DbManager<TEntity> where TEntity : class
    {
        private readonly DbConntent _context;
        private readonly DbSet<TEntity> _entities;

        public DbManager(DbConntent context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable().AsNoTracking();
        }
    }
}
