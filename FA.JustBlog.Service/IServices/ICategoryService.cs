using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.IServices
{
    public interface ICategoryService
    {
        Category Find(int entityId);
        void AddCategory(Category entity);
        void UpdateCategory(Category entity);
        void DeleteCategory(Category entity);
        void DeleteCategory(int entityId);
        IEnumerable<Category> GetAllEntities();
        Category GetCategoryByName(string name);
        Category GetCategoriesByPostId(int postId);
        public IEnumerable<Category> CategoryPagination(int pageSize, int PageIndex);
    }
}
