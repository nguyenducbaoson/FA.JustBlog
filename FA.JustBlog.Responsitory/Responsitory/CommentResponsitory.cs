using FA.JustBlog.Entities.Data;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.Responsitory
{
    public class CommentRepository : BaseReponsitory<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            db.Comments.Add(new Comment { Name = commentName, Email = commentEmail, PostId = postId, CommentHeader = commentTitle, CommentText = commentBody, CommentTime = DateTime.Now });
        }

        public IList<Comment> GetAllComments()
        {
            return db.Set<Comment>().ToList();
            //return db.Comments.Include(p => p.Post).ToList();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            if (db.Set<Post>().Find(postId) == null || db.Set<Post>().Find(postId).Comments == null)
            {
                return new List<Comment>();
            }
            return db.Set<Post>().Find(postId).Comments.ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            if (db.Set<Post>().Find(post.PostId) == null || db.Set<Post>().Find(post.PostId).Comments == null)
            {
                return new List<Comment>();
            }
            return db.Set<Post>().Find(post.PostId).Comments.ToList();
        }
    }
}
