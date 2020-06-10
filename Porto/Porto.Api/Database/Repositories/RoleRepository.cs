using Porto.Api.Database.Contexts;
using Porto.Api.Models;

namespace Porto.Api.Database.Repositories
{
    public interface IRoleRepository
    {
    }

    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ProtoDbContext context)
            : base(context)
        {
        }
    }
}
