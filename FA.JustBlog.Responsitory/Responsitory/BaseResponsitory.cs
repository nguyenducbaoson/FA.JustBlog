using FA.JustBlog.Entities.Data;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FA.JustBlog.Responsitory.Responsitory
{
    public abstract class BaseReponsitory<TEntity> : IBaseReponsitory<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext db;

        public BaseReponsitory(ApplicationDbContext context)
        {
            db = context;
        }

        string entity = typeof(TEntity).Name;

        public virtual void AddTEntity(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }


        public virtual void DeleteTEntity(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteTEntity(int entityId)
        {
            db.Set<TEntity>().Remove(db.Set<TEntity>().Find(entityId));
        }

        public virtual TEntity Find(int entityId)
        {
            return db.Set<TEntity>().Find(entityId);
        }

        public virtual IEnumerable<TEntity> GetAllEntities()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual void UpdateTEntity(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }

        public IEnumerable<TEntity> Pagination(int pageSize, int pageIndex)
        {
            return db.Set<TEntity>().Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
