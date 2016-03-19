namespace Flags.Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFlagsDbContext
    {
        IDbSet<Flag> Flags { get; set; }

        IDbSet<Score> Scores { get; set; }

        void Save();
    }
}
