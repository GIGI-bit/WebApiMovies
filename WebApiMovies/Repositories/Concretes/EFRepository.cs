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

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
