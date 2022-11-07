using FA.JustBlog.Entities.Models;
namespace FA.JustBlog.Service.IServices
{
    public interface IPostService
    {
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetAllEntities();
        Post Find(int entityId);
        void AddPost(Post entity);
        void UpdatePost(Post entity);
        void DeletePost(Post entity);
        void DeletePost(int entityId);
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost(int size);
        int CountPostsForCategory(int category);
        IList<Post> GetPostsByCategory(string categoryName);
        IList<Post> GetHighestPosts(int size);
        public IEnumerable<Post> PostPagination(int pageSize, int PageIndex);
        dynamic GetPostWithCategory();
        dynamic GetLastestPostWithCategory(int size);
        dynamic GetMostPostWithCategory(int size);

    }
}
