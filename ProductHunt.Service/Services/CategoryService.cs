using ProductHunt.Data.Entity;
using ProductHunt.Data.IRepository;
using ProductHunt.Domain.Models;
using ProductHunt.Service.IServices;

namespace ProductHunt.Service.Services
{
    public class CategoryService : BaseService<CategoryModel, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}