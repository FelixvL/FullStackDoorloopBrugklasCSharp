using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFSDoorloop
{
    class FullStackDBContext : DbContext
    {
        public DbSet<Kapitein> Kapiteins { get; set; }
    }
}
