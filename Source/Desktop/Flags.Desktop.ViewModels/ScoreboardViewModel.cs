namespace Flags.Desktop.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data;

    public class ScoreboardViewModel : IScoreboard
    {
        public ScoreboardViewModel(IFlagsDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.UpdateScores();
        }

        public ICollection<ScoreViewModel> Scores { get; set; }

        public IFlagsDbContext DbContext { get; set; }

        public string RestartGameButtonContent { get; set; } = "Restart game";

        public string ExitGameButtonContent { get; set; } = "Exit game";

        public void UpdateScores()
        {
            this.Scores = this.DbContext.Scores
                .Select(x => new ScoreViewModel
                {
                    PlayerName = x.PlayerName,
                    Value = x.Value
                })
                .OrderByDescending(x=> x.Value)
                .ToList();
        }
    }
}