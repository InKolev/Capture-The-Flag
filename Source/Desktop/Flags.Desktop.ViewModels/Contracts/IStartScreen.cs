namespace Flags.Desktop.ViewModels.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IStartScreen
    {
        string GameTitle { get; set; }

        string GameStartButton { get; set; }

        string PlayerNameLabel { get; set; }

        string PlayerName { get; set; }
    }
}