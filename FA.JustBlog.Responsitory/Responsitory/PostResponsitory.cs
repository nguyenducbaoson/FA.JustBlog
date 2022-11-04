using FA.JustBlog.Entities.Data;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace FA.JustBlog.Responsitory.Responsitory
{
    public class PostResponsitory : BaseReponsitory<Post>, IPostResponsitory
    {
        public PostResponsitory(ApplicationDbContext context) : base(context)
        {

        }
        public int CountPostsForCategory(int category)
        {
            //return db.Set<Post>().Include(Post => Post.Category).ThenInclude(Post => Post.Name == category).Count();
            return db.Set<Post>().Where(Post => Post.Category.CategoryId == category).Count();
        }

        public IList<Post> GetAllPosts()
        {
            return db.Set<Post>().ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return db.Set<Post>().OrderByDescending(x => x.RateCount).Take(size).ToList();
        }

        public dynamic GetLastestPostWithCategory(int size)
        {
            return db.Set<Post>().Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(pt => pt.Tag).OrderByDescending(p => p.PostOn).Take(size);
        }

        public IList<Post> GetLatestPost(int size)
        {
            return db.Set<Post>().OrderByDescending(p => p.PostOn).Take(size).ToList();
        }

        public dynamic GetMostPostWithCategory(int size)
        {
            return db.Set<Post>().Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(pt => pt.Tag).OrderByDescending(p => p.ViewCount).Take(size);
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return db.Set<Post>().OrderByDescending(x => x.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string categoryName)
        {
            return db.Set<Post>().Where(x => x.Category.CategoryName.Contains(categoryName)).ToList();
        }

        public dynamic GetPostWithCategory()
        {
            return db.Set<Post>().Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(pt => pt.Tag);
        }

        public IList<Post> GetPublisedPosts()
        {
            return db.Set<Post>().Where(x => x.Published == true).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return db.Set<Post>().Where(x => x.Published == false).ToList();
        }
    }
}
