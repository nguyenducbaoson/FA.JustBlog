using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.IResponsitory
{
    public interface ICommentRepository : IBaseReponsitory<Comment>
    {
        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
        IList<Comment> GetAllComments();
        IList<Comment> GetCommentsForPost(int postId);
        IList<Comment> GetCommentsForPost(Post post);
    }
}
