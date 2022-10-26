using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.IResponsitory
{
    public interface IBaseReponsitory<TEntity>
    {
        TEntity Find(int entityId);
        void AddTEntity(TEntity entity);
        void UpdateTEntity(TEntity entity);
        void DeleteTEntity(TEntity entity);
        void DeleteTEntity(int entityId);
        IEnumerable<TEntity> GetAllEntities();
        IEnumerable<TEntity> Pagination(int pageSize, int pageIndex);
    }
}
