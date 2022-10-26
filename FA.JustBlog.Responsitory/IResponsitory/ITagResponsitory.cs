using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.IResponsitory
{
    public interface ITagReponsitory : IBaseReponsitory<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);
        Tag GetTagByName(string name);
        IEnumerable<Tag> GetTagsByPostId(int postId);
    }
}
