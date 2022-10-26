using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Entities.Models
{
    public class Tag : BaseModel
    {
        [Key]
        public int TagId { get; set; }
        [Required(ErrorMessage = "Tag name is required.")]
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public int Count { get; set; }
        public virtual ICollection<PostTagMap>? PostTagMaps { get; set; }
    }
}
