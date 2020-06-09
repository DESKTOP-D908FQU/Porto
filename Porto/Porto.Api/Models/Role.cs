using System;
using Microsoft.AspNetCore.Identity;

namespace Porto.Api.Models
{
    public class Role : IdentityRole<long>, IEntity<long>
    {
        public Role()
        {
            CreatedAt = DateTime.Now.ToUniversalTime();
            UpdatedAt = DateTime.Now.ToUniversalTime();
        }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
