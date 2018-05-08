using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductHunt.Data.Entity;
using ProductHunt.Data.IRepository;

namespace ProductHunt.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;


        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public T Add(T value)
        {
            _context.Set<T>().Add(value);
            return value;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> value)
        {
            var addRange = value as T[] ?? value.ToArray();
            _context.Set<T>().AddRange(addRange);
            return addRange;
        }

        public T Update(T value)
        {
            var dbValue = _context.Set<T>().FirstOrDefault(p => p.Id == value.Id);
            if (dbValue != null)
            {
                _context.Entry(dbValue).CurrentValues.SetValues(value);
            }
            return value;
        }

        public void Delete(int id)
        {
            var dbValue = _context.Set<T>().FirstOrDefault(p => p.Id == id);
            if (dbValue != null)
            {
                _context.Set<T>().Remove(dbValue);
            }
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public ICollection<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            return _context.Set<T>().Where(predicate).Skip(skip).Take(take).ToList();
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<ICollection<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            var res = await _context.Set<T>().Where(predicate).ToListAsync();
            return res;
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            return await _context.Set<T>().Where(predicate).Skip(skip).Take(take).ToListAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
