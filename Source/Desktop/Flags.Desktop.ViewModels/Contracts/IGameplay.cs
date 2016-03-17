namespace Flags.Desktop.ViewModels.Contracts
{
    using Data;
    using Data.Models;
    using System.Collections.Generic;

    public interface IGameplay
    {
        IFlagsDbContext DbContext { get; set; }

        List<FlagViewModel> Flags { get; set; }

        List<FlagViewModel> PossibleFlags { get; set; }

        FlagViewModel ActualFlag { get; set; }

        string RemainingTime { get; }

        string PlayerName { get; set; }

        int PlayerScore { get; set; }

        int RemainingTimeInSeconds { get; set; }

        void LoadNextQuestion();

        void LoadFlags();

        void IncreaseScore();

        void DecreaseScore();

        void UpdateTime();
    }
}