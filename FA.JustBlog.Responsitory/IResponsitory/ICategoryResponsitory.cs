using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.IResponsitory
{
    public interface ICategoryReponsitory : IBaseReponsitory<Category>
    {
        public Category GetCategoryByName(string name);
        public Category GetCategoriesByPostId(int postId);
    }
}
