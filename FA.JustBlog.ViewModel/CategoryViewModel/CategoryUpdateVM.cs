using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.CategoryViewModel
{
    public class CategoryUpdateVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public ICollection<int> PostId { get; set; }
    }
}
