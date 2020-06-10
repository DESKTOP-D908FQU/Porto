using Microsoft.AspNetCore.Identity;

namespace Porto.Api.Models
{
    public class UserRole : IdentityUserRole<long>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
