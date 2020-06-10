using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Porto.Api.Models
{
    public class User : IdentityUser<long>, IEntityWithTypedId<long>, IEntityDate, IEntityEnabled, IEntityDeleted
    {
        public User()
        {
            var currentTime = DateTimeOffset.Now;

            CreatedAt = CreatedAt == default ? currentTime : CreatedAt;
            UpdatedAt = UpdatedAt == default ? currentTime : UpdatedAt;
        }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public bool Enabled { get; set; }

        public bool IsDeleted { get; set; }
    }
}
