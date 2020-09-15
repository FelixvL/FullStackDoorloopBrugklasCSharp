using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFSDoorloop
{
    public class FullStackDBContext : DbContext
    {
        public FullStackDBContext() {
            Database.SetInitializer<FullStackDBContext>(null);
        }
        public DbSet<Kapitein> Kapiteins { get; set; }
    }
}
