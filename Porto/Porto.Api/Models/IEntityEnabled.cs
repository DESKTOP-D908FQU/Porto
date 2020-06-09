using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Porto.Api.Models
{
    public interface IEntityEnabled
    {
        [Required]
        [DefaultValue(true)]
        public bool Enabled { get; set; }
    }
}
