using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Porto.Api.Models
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
