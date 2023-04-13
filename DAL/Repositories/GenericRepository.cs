using System.Linq.Expressions;
using DAL.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationContext ApplicationContext { get; set; }

        public GenericRepository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await ApplicationContext.Set<T>().ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await ApplicationContext.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await ApplicationContext.Set<T>().AddAsync(entity, cancellationToken);
            await ApplicationContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            ApplicationContext.Set<T>().Update(entity);
            await ApplicationContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            ApplicationContext.Set<T>().Remove(entity);
            await ApplicationContext.SaveChangesAsync(cancellationToken);
        }
    }
}