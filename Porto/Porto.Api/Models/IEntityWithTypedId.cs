using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Porto.Api.Models
{
    public interface IEntityWithTypedId<out TKey>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        TKey Id { get; }
    }
}
