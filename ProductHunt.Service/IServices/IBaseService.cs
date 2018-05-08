using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductHunt.Data.Entity;
using ProductHunt.Domain.Models;

namespace ProductHunt.Service.IServices
{
    public interface IBaseService<TModel, TEntity> where TModel : BaseModel where TEntity : BaseEntity
    {
        Task<TModel> Add(TModel value);

        Task<TModel> Update(TModel value);

        void Delete(int id);

        void SaveChanges();

        Task SaveChangesAsync();

        TModel Find(Expression<Func<TEntity, bool>> predicate);

        Task<TModel> FindAsync(Expression<Func<TEntity, bool>> predicate);

        ICollection<TModel> FindAll();

        ICollection<TModel> FindAll(Expression<Func<TEntity, bool>> predicate);

        ICollection<TModel> FindAll(Expression<Func<TEntity, bool>> predicate, int skip, int take);

        IQueryable<TModel> FindQueryable(Expression<Func<TEntity, bool>> predicate);

        Task<ICollection<TModel>> FindAllAsync();

        Task<ICollection<TModel>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<ICollection<TModel>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take);

    }
}