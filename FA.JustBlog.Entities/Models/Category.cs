using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Entities.Models
{
    public class Category : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string CategoryName { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
    }
}
