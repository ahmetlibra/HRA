using Core.Data.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.HrsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Repositories.Ef
{
    public class EfEntityRepostoryBase<T> : IPgRepository<T> where T : class, IEntity, new()
    {
        private readonly HrsUserDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfEntityRepostoryBase(HrsUserDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await _dbSet.Where(filter).ToListAsync();

            return await _dbSet.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                await Delete(entity);
            }
        }
    }
}
