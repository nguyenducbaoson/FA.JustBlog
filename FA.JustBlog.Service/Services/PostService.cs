using Microsoft.Extensions.Configuration;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory;

namespace FA.JustBlog.Service.Services
{
    public class PostService :IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Post> GetAllEntities()
        {
            var posts = _unitOfWork.postRepository.GetAllPosts();
            return posts;
        }
        public IList<Post> GetMostViewedPost(int size)
        {
            var posts = _unitOfWork.postRepository.GetMostViewedPost(size).ToList();
            return posts;
        }

        public void AddPost(Post entity)
        {
            _unitOfWork.postRepository.AddTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public int CountPostsForCategory(int category)
        {
            int result = _unitOfWork.postRepository.CountPostsForCategory(category);
            return result;
        }

        public void DeletePost(Post entity)
        {
            _unitOfWork.postRepository.DeleteTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeletePost(int entityId)
        {
            _unitOfWork.postRepository.DeleteTEntity(entityId);
            _unitOfWork.SaveChanges();
        }

        public Post Find(int entityId)
        {
            var post = _unitOfWork.postRepository.Find(entityId);
            return post;
        }
        public IList<Post> GetHighestPosts(int size)
        {
            var posts = _unitOfWork.postRepository.GetHighestPosts(size);
            return posts;
        }

        public IList<Post> GetLatestPost(int size)
        {
            var posts = _unitOfWork.postRepository.GetLatestPost(size);
            return posts;
        }
        public IList<Post> GetPostsByCategory(string categoryName)
        {
            var posts = _unitOfWork.postRepository.GetPostsByCategory(categoryName);
            return posts;
        }

        public IList<Post> GetPublisedPosts()
        {
            var posts = _unitOfWork.postRepository.GetPublisedPosts();
            return posts;
        }

        public IList<Post> GetUnpublisedPosts()
        {
            var posts = _unitOfWork.postRepository.GetUnpublisedPosts();
            return posts;
        }

        public void UpdatePost(Post entity)
        {
            _unitOfWork.postRepository.UpdateTEntity(entity);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<Post> PostPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.postRepository.Pagination(pageSize, PageIndex);
        }

        public dynamic GetPostWithCategory()
        {
            return _unitOfWork.postRepository.GetPostWithCategory();
        }

        public dynamic GetLastestPostWithCategory(int size)
        {
            return _unitOfWork.postRepository.GetLastestPostWithCategory(size);
        }

        public dynamic GetMostPostWithCategory(int size)
        {
            return _unitOfWork.postRepository.GetMostPostWithCategory(size);
        }
    }
}
