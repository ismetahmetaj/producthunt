using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductHunt.Data.Entity;

namespace ProductHunt.Data.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T value);
        IEnumerable<T> AddRange(IEnumerable<T> value);
        T Update(T value);

        void Delete(int id);

        T Find(Expression<Func<T, bool>> predicate);

        ICollection<T> FindAll();

        ICollection<T> FindAll(Expression<Func<T, bool>> predicate);

        ICollection<T> FindAll(Expression<Func<T, bool>> predicate, int skip, int take);

        IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        int SaveChanges();
        Task<int> SaveChangesAsync();

        Task<ICollection<T>> FindAllAsync();

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate, int skip, int take);

    }
}
