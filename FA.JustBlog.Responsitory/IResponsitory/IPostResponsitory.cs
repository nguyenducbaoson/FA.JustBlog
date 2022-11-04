using FA.JustBlog.Entities.Models;
using System.Linq.Expressions;

namespace FA.JustBlog.Responsitory.IResponsitory
{
    public interface IPostResponsitory : IBaseReponsitory<Post>
    {
        IList<Post> GetAllPosts();
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost(int size);
        int CountPostsForCategory(int category);
        IList<Post> GetPostsByCategory(string categoryName);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
        dynamic GetPostWithCategory();
        dynamic GetLastestPostWithCategory(int size);
        dynamic GetMostPostWithCategory(int size);

    }
}
