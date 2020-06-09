using Microsoft.EntityFrameworkCore;

namespace Porto.Api.Data
{
    public class ProtoDbContext : DbContext
    {
        public const string Position = "DefaultConnection";

        public ProtoDbContext(DbContextOptions<ProtoDbContext> options)
            : base(options)
        {
        }
    }
}
