using FA.JustBlog.Entities.Enum;

namespace FA.JustBlog.Entities.Models
{
    public class BaseModel
    {
        public DateTime CreateAt { get; set; }
        public DateTime Modify { get; set; }
        public Status Status { get; set; }
    }
}
