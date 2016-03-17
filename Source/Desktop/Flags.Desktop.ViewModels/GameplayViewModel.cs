namespace Flags.Desktop.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Contracts;
    using Data;
    using Infrastructure.Extensions;

    public class GameplayViewModel : IGameplay, INotifyPropertyChanged
    {
        // Constants
        private const int FakeFlagsPerRound = 4;
        private const int ScorePointsPerAnswer = 1000;

        // Fields
        private List<FlagViewModel> possibleFlags;
        private FlagViewModel actualFlag;
        private int playerScore = 0;
        private int remainingTime = 60;

        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        // Constructors
        public GameplayViewModel(IFlagsDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.LoadFlags();
            this.LoadNextQuestion();
        }

        // Properties
        public IFlagsDbContext DbContext { get; set; }

        public List<FlagViewModel> Flags { get; set; }

        public List<FlagViewModel> PossibleFlags
        {
            get
            {
                return this.possibleFlags;
            }
            set
            {
                this.possibleFlags = value;
                this.NotifyPropertyChanged(Helpers.GetPropertyName(() => this.PossibleFlags));
            }
        }

        public FlagViewModel ActualFlag
        {
            get
            {
                return this.actualFlag;
            }
            set
            {
                this.actualFlag = value;
                this.NotifyPropertyChanged(Helpers.GetPropertyName(() => this.ActualFlag));
            }
        }

        public string PlayerName { get; set; } = "Martin Lawrence";

        public int PlayerScore
        {
            get
            {
                return this.playerScore;
            }
            set
            {
                this.playerScore = value;
                this.NotifyPropertyChanged(Helpers.GetPropertyName(() => this.PlayerScore));
            }
        }

        public string RemainingTime
        {
            get
            {
                return $"Time left: 00:00:{this.remainingTime} seconds";
            }
        }

        public int RemainingTimeInSeconds
        {
            get
            {
                return this.remainingTime;
            }
            set
            {
                this.remainingTime = value;
                this.NotifyPropertyChanged(Helpers.GetPropertyName(() => this.RemainingTime));
            }
        }

        // Methods
        public void LoadNextQuestion()
        {
            this.ActualFlag = this.Flags.Where(x => !x.IsUsed).FirstOrDefault();

            if(this.ActualFlag == null)
            {
                this.RemainingTimeInSeconds = 0;
                return;
            }

            this.ActualFlag.IsUsed = true;

            this.PossibleFlags = this.Flags
                .Where(x=> x.Id != this.ActualFlag.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(FakeFlagsPerRound)
                .ToList();
            this.PossibleFlags.Add(ActualFlag);
            this.PossibleFlags.Shuffle();

            this.NotifyPropertyChanged(Helpers.GetPropertyName(() => this.PossibleFlags));
        }

        public void LoadFlags()
        {
            this.Flags = this.DbContext.Flags
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new FlagViewModel()
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Name = x.Name
                })
                .ToList();
        }

        public void IncreaseScore()
        {
            this.PlayerScore += ScorePointsPerAnswer;
        }

        public void DecreaseScore()
        {
            this.PlayerScore -= ScorePointsPerAnswer;
        }

        public void UpdateTime()
        {
            this.RemainingTimeInSeconds -= 1;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}