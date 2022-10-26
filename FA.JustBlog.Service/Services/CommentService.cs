using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModel.PostViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.Services
{
    public class CommentService:ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddComment(Comment entity)
        {
            _unitOfWork.commentResponsitory.AddTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteComment(Comment entity)
        {
            _unitOfWork.commentResponsitory.DeleteTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteComment(int entityId)
        {
            _unitOfWork.commentResponsitory.DeleteTEntity(entityId);
            _unitOfWork.SaveChanges();
        }

        public Comment Find(int entityId)
        {
            var comment = _unitOfWork.commentResponsitory.Find(entityId);
            return comment;
        }

        public IList<Comment> GetAllEntities()
        {
            var posts = _unitOfWork.commentResponsitory.GetAllComments();
            return posts;
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            var comments = _unitOfWork.commentResponsitory.GetCommentsForPost(postId);
            return comments;
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            var comments = _unitOfWork.commentResponsitory.GetCommentsForPost(post);
            return comments;
        }

        public void UpdateComment(Comment entity)
        {
            _unitOfWork.commentResponsitory.UpdateTEntity(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
