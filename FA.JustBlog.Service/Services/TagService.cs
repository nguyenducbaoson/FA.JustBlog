using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory;
using FA.JustBlog.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTag(Tag entity)
        {
            _unitOfWork.tagResponsitory.AddTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTag(Tag entity)
        {
            _unitOfWork.tagResponsitory.DeleteTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTag(int entityId)
        {
            _unitOfWork.tagResponsitory.DeleteTEntity(entityId);
            _unitOfWork.SaveChanges();
        }

        public Tag Find(int entityId)
        {
            var tag = _unitOfWork.tagResponsitory.Find(entityId);
            return tag;
        }

        public IEnumerable<Tag> GetAllEntities()
        {
            var tags = _unitOfWork.tagResponsitory.GetAllEntities();
            return tags;
        }

        public Tag GetTagByName(string name)
        {
            var tag = _unitOfWork.tagResponsitory.GetTagByName(name);
            return tag;
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            var tag = _unitOfWork.tagResponsitory.GetTagByUrlSlug(urlSlug);
            return tag;
        }

        public IEnumerable<Tag> GetTagsByPostId(int postId)
        {
            var tags = _unitOfWork.tagResponsitory.GetTagsByPostId(postId);
            return tags;
        }

        public void UpdateTag(Tag entity)
        {
            _unitOfWork.tagResponsitory.UpdateTEntity(entity);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<Tag> TagPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.tagResponsitory.Pagination(pageSize, PageIndex);
        }
    }
}
