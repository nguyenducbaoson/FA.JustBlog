

namespace FA.JustBlog.ViewModel.CategoryViewModel
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public ICollection<int>? PostId { get; set; }
    }
}
 