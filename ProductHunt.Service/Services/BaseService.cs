using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProductHunt.Data.Entity;
using ProductHunt.Data.IRepository;
using ProductHunt.Domain.Models;
using ProductHunt.Service.IServices;

namespace ProductHunt.Service.Services
{
    public class BaseService<TModel, TEntity> : IBaseService<TModel, TEntity> where TModel : BaseModel where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> Repository;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public virtual async Task<TModel> Add(TModel value)
        {
            var entity = Repository.Add(Mapper.Map<TEntity>(value));
            await SaveChangesAsync();
            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Update(TModel value)
        {
            var model = Repository.Update(Mapper.Map<TEntity>(value));
            await SaveChangesAsync();
            return Mapper.Map<TModel>(model);
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);
        }


        public virtual TModel Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Mapper.Map<TModel>(Repository.Find(predicate));
        }


        public virtual ICollection<TModel> FindAll()
        {
            return Mapper.Map<ICollection<TModel>>(Repository.FindAll());
        }

        public virtual ICollection<TModel> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Mapper.Map<ICollection<TModel>>(Repository.FindAll(predicate));
        }

        public virtual ICollection<TModel> FindAll(Expression<Func<TEntity, bool>> predicate, int skip, int take)
        {
            return Mapper.Map<ICollection<TModel>>(Repository.FindAll(predicate, skip, take));
        }

        public virtual IQueryable<TModel> FindQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return Mapper.Map<IQueryable<TModel>>(Repository.FindQueryable(predicate));
        }

        public virtual async Task<TModel> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await Repository.FindAsync(predicate);
            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task<ICollection<TModel>> FindAllAsync()
        {
            return Mapper.Map<ICollection<TModel>>(await Repository.FindAllAsync());

        }

        public virtual async Task<ICollection<TModel>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Mapper.Map<ICollection<TModel>>(await Repository.FindAllAsync(predicate));

        }

        public virtual async Task<ICollection<TModel>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take)
        {
            return Mapper.Map<ICollection<TModel>>(await Repository.FindAllAsync(predicate));
        }

        public void SaveChanges()
        {
            UnitOfWork.Commit();
        }

        public async Task SaveChangesAsync()
        {
            await UnitOfWork.CommitAsync();
        }


    }
}
