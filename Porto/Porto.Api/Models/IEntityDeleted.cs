using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Porto.Api.Models
{
    public interface IEntityDeleted
    {
        [Required]
        public bool IsDeleted { get; set; }
    }
}
