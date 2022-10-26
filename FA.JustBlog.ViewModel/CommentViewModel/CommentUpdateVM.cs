using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.CommentViewModel
{
    public class CommentUpdateVM
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
    }
}
