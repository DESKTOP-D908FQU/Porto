using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Porto.Api.Database.Contexts.EntityConfigurations.Identities
{
    public class IdentityUserEntityConfiguration : IEntityTypeConfiguration<IdentityUser<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUser<long>> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}
