using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.PostViewModel
{
    public class PostCreateVM
    {
        public string Title { get; set; }
        public string ShortDecription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool? Published { get; set; }
        public int CategoryId { get; set; }
        public ICollection<int>? TagId { get; set; }
    }
}
