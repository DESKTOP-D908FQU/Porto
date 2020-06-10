using Microsoft.EntityFrameworkCore;
using Porto.Api.Database.Contexts;
using Porto.Api.Models;

namespace Porto.Api.Database.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class, IEntityWithTypedId<long>
    {
        private readonly ProtoDbContext _context;

        public BaseRepository(ProtoDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Entities => _context.Set<TEntity>();
    }
}
