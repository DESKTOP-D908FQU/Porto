using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Porto.Api.Data
{
    public class ProtoDbContext : DbContext
    {
        public ProtoDbContext(DbContextOptions<ProtoDbContext> options)
            : base(options)
        {
        }
    }
}
