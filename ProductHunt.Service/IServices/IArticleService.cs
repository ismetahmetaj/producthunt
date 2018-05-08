using ProductHunt.Data.Entity;
using ProductHunt.Domain.Models;

namespace ProductHunt.Service.IServices
{
    public interface IArticleService : IBaseService<ArticleModel,Article>
    {

    }
}