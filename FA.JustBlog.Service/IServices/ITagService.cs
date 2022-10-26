using FA.JustBlog.Entities.Models;

namespace FA.JustBlog.Service.IServices
{
    public interface ITagService
    {
        Tag Find(int entityId);
        void AddTag(Tag entity);
        void UpdateTag(Tag entity);
        void DeleteTag(Tag entity);
        void DeleteTag(int entityId);
        IEnumerable<Tag> GetAllEntities();
        Tag GetTagByUrlSlug(string urlSlug);
        Tag GetTagByName(string name);
        IEnumerable<Tag> GetTagsByPostId(int postId);
        public IEnumerable<Tag> TagPagination(int pageSize, int PageIndex);
    }
}
