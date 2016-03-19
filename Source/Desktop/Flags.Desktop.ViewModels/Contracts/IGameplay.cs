namespace Flags.Desktop.ViewModels.Contracts
{
    using Data;
    using Data.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    public interface IGameplay
    {
        IFlagsDbContext DbContext { get; set; }

        List<FlagViewModel> Flags { get; set; }

        List<FlagViewModel> PossibleFlags { get; set; }

        FlagViewModel ActualFlag { get; set; }

        string RemainingTime { get; }

        string PlayerName { get; set; }

        string PlayerScore { get; }

        int Score { get; set; }

        string RemainingFlags { get; }

        int RemainingTimeInSeconds { get; set; }

        void LoadNextQuestion();

        void LoadFlags();

        void IncreaseScore();

        void DecreaseScore();

        void UpdateTime();
    }
}