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
    public class TagRepository : BaseReponsitory<Tag>, ITagReponsitory
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Tag GetTagByName(string name)
        {
            return db.Set<Tag>().FirstOrDefault(x => x.Name == name);

        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return db.Tags.Where(x => x.UrlSlug.Equals(urlSlug)).FirstOrDefault();
        }

        public IEnumerable<Tag> GetTagsByPostId(int postId)
        {
            var tagIds = db.Set<PostTagMap>().Where(x => x.PostId == postId).Select(x => x.TagId);
            return db.Set<Tag>().Where(x => tagIds.Contains(x.TagId));

        }
    }
}
