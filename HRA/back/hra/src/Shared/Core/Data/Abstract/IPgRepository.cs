using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Abstract
{
    public interface IPgRepository<T>  where T : class, IEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);

        Task<T> Get(Expression<Func<T, bool>> filter);

        Task<T> GetById(Guid Id);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task Delete(Guid Id);
    }
}
