using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory;
using FA.JustBlog.Service.IServices;
namespace FA.JustBlog.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCategory(Category entity)
        {
            _unitOfWork.categoryRepository.AddTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCategory(Category entity)
        {
            _unitOfWork.categoryRepository.DeleteTEntity(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCategory(int entityId)
        {
            _unitOfWork.categoryRepository.DeleteTEntity(entityId);
            _unitOfWork.SaveChanges();
        }
        public Category Find(int entityId)
        {
            var category = _unitOfWork.categoryRepository.Find(entityId);
            return category;
        }

        public IEnumerable<Category> GetAllEntities()
        {
            var categorys = _unitOfWork.categoryRepository.GetAllEntities();
            return categorys;
        }

        public Category GetCategoryByName(string name)
        {
            var category = _unitOfWork.categoryRepository.GetCategoryByName(name);
            return category;
        }

        public Category GetCategoriesByPostId(int postId)
        {
            var categories = _unitOfWork.categoryRepository.GetCategoriesByPostId(postId);
            return categories;
        }

        public void UpdateCategory(Category entity)
        {
            _unitOfWork.categoryRepository.UpdateTEntity(entity);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<Category> CategoryPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.categoryRepository.Pagination(pageSize, PageIndex);
        }
    }
}
