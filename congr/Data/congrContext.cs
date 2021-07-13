using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using congr.Models;

namespace congr.Data
{
    public class congrContext : DbContext
    {
        public congrContext (DbContextOptions<congrContext> options)
            : base(options)
        {
        }

        public DbSet<congr.Models.Birthday> Birthday { get; set; }
    }
}
