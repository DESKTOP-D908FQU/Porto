using Porto.Api.Database.Contexts;
using Porto.Api.Models;

namespace Porto.Api.Database.Repositories
{
    public interface IUserRepository
    {
    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProtoDbContext context)
            : base(context)
        {
        }
    }
}
