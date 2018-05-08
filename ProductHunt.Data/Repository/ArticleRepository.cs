using System.Threading;
using ProductHunt.Data.Entity;
using ProductHunt.Data.IRepository;

namespace ProductHunt.Data.Repository
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}