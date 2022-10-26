using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Entities.Models
{
    public class Post : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDecription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool? Published { get; set; }
        public DateTime? PostOn { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PostTagMap>? PostTagMaps { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public int? ViewCount { get; set; }
        public int? RateCount { get; set; }
        public int? TotalRate { get; set; }

        public decimal? Rate
        {
            get
            {
                return TotalRate / RateCount;
            }
        }
    }
}
