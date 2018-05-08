using ProductHunt.Data.Entity;
using ProductHunt.Data.IRepository;
using ProductHunt.Domain.Models;
using ProductHunt.Service.IServices;

namespace ProductHunt.Service.Services
{
    public class ArticleService : BaseService<ArticleModel,Article>, IArticleService
    {
        public ArticleService(IArticleRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}