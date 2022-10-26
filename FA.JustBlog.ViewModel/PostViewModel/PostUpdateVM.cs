using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.PostViewModel
{
    public class PostUpdateVM
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDecription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool? Published { get; set; }

        public int CategoryId { get; set; }
        public ICollection<int> TagId { get; set; }
        public ICollection<int> CommentId { get; set; }
        //public int? ViewCount { get; set; }
        //public int? RateCount { get; set; }
        //public int? TotalRate { get; set; }

        //public decimal? Rate
        //{
        //    get
        //    {
        //        return TotalRate / RateCount;
        //    }
        //}
    }
}
