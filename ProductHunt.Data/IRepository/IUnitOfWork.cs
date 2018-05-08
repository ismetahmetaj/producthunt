using System.Threading.Tasks;

namespace ProductHunt.Data.IRepository
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();
    }
}