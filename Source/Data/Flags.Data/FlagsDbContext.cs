namespace Flags.Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FlagsDbContext : DbContext, IFlagsDbContext
    {
        public FlagsDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Flag> Flags { get; set; }
    }
}