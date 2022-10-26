
using FA.JustBlog.Entities.Data;
using FA.JustBlog.Responsitory.IResponsitory;

namespace FA.JustBlog.Responsitory
{
    public interface IUnitOfWork : IDisposable
    {
        public IPostResponsitory postRepository { get; }
        public ICategoryReponsitory categoryRepository { get; }
        public ITagReponsitory tagResponsitory { get; }
        public ICommentRepository commentResponsitory { get; }
        public ApplicationDbContext AppDbContext { get; }
        int SaveChanges();
    }
}
