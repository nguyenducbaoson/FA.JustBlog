using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.Entities.Data;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Responsitory.Responsitory
{
    public class CategoryReponsitory : BaseReponsitory<Category>, ICategoryReponsitory
    {
        public CategoryReponsitory(ApplicationDbContext context) : base(context)
        {
        }

        public Category GetCategoryByName(string name)
        {
            var category = db.Set<Category>().FirstOrDefault(x => x.CategoryName == name);
            return category;
        }

        public Category GetCategoriesByPostId(int id)
        {
            var categories = db.Set<Category>().Where(x => x.CategoryId == db.Set<Post>().FirstOrDefault(x => x.PostId == id).CategoryId).FirstOrDefault();
            return categories;
        }
       
    }
}
