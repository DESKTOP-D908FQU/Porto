using System;
using Microsoft.AspNetCore.Identity;

namespace Porto.Api.Models
{
    public class User : IdentityUser<long>, IEntity<long>
    {
        public User()
        {
            CreatedAt = DateTime.Now.ToUniversalTime();
            UpdatedAt = DateTime.Now.ToUniversalTime();
        }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
