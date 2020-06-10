using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porto.Api.Models;

namespace Porto.Api.Database.Contexts.EntityConfigurations
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(c => c.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(c => c.RoleId)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(c => c.UserId)
                .IsRequired();
        }
    }
}
