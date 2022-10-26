using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.IServices
{
    public interface ICommentService
    {
        Comment Find(int entityId);
        void AddComment(Comment entity);
        void UpdateComment(Comment entity);
        void DeleteComment(Comment entity);
        void DeleteComment(int entityId);
        IList<Comment> GetAllEntities();
        IList<Comment> GetCommentsForPost(int postId);
        IList<Comment> GetCommentsForPost(Post post);
    }
}
