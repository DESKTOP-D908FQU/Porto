using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Porto.Api.Database.Contexts.EntityConfigurations;
using Porto.Api.Database.Contexts.EntityConfigurations.Identities;
using Porto.Api.Models;

namespace Porto.Api.Database.Contexts
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

            modelBuilder.ApplyConfiguration(new IdentityUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        }
    }
}
