namespace Flags.Desktop.ViewModels.Contracts
{
    using System.Collections.Generic;

    using Data;

    public interface IScoreboard
    {
        ICollection<ScoreViewModel> Scores { get; set; }

        IFlagsDbContext DbContext { get; set; }

        string RestartGameButtonContent { get; set; }

        string ExitGameButtonContent { get; set; }

        void UpdateScores();
    }
}
