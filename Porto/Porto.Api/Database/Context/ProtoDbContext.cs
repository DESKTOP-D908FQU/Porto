using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Porto.Api.Models;

namespace Porto.Api.Database.Context
{
    public class ProtoDbContext : IdentityDbContext<User, Role, long>
    {
        public const string Position = "DefaultConnection";

        public ProtoDbContext(DbContextOptions<ProtoDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
