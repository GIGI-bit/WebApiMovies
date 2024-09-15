using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Principal;
using WebApiMovies.Repositories.Abstracts;

namespace WebApiMovies.Repositories.Concretes
{
    public class EFRepository<TEntity, TContext>
        : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext
    {
        private readonly TContext context;

        public EFRepository(TContext context)
        {
            this.context = context;
        }

        public async Task Add(TEntity entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            await Task.Run(() =>
            {
                context.Remove(entity);
            });
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ?
               await context.Set<TEntity>().ToListAsync() :
           await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(expression);
        }
    }
}
