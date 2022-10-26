
using FA.JustBlog.Entities.Data;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.Responsitory.Responsitory;

namespace FA.JustBlog.Responsitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IPostResponsitory _postRepository;
        private ICategoryReponsitory _categoryResponsitory;
        private ICommentRepository _commentResponsitory;
        private ITagReponsitory _tagResponsitory;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICommentRepository commentResponsitory => _commentResponsitory ?? (_commentResponsitory = new CommentRepository(_context));

        public ITagReponsitory tagResponsitory => _tagResponsitory ?? (_tagResponsitory = new TagRepository(_context));

        public ApplicationDbContext AppDbContext => _context;

        public IPostResponsitory postRepository => _postRepository ?? (_postRepository = new PostResponsitory(_context));

        public ICategoryReponsitory categoryRepository => _categoryResponsitory ?? (_categoryResponsitory = new CategoryReponsitory(_context));

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
