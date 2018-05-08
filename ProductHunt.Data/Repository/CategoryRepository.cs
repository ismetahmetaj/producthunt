using ProductHunt.Data.Entity;
using ProductHunt.Data.IRepository;

namespace ProductHunt.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}