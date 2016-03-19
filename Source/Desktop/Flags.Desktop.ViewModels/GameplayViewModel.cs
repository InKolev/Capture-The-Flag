namespace Flags.Desktop.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Contracts;
    using Data;
    using Infrastructure.Extensions;
    using System.Collections.ObjectModel;
    using Infrastructure.Helpers;

    public class GameplayViewModel : IGameplay, INotifyPropertyChanged
    {
        // Constants
        private const int FakeFlagsPerRound = 4;
        private const int ScorePointsPerAnswer = 1000;

        // Fields
        private List<FlagViewModel> possibleFlags;
        private FlagViewModel actualFlag;
        private string playerName;
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
                this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.PossibleFlags));
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
                this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.ActualFlag));
            }
        }

        public string PlayerName
        {
            get
            {
                return $"Player: {this.playerName}";
            }
            set
            {
                this.playerName = value;
                this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.PlayerName));
            }
        }

        public string PlayerScore
        {
            get
            {
                return $"Score: {this.Score}";
            }
        }

        public int Score
        {
            get
            {
                return this.playerScore;
            }
            set
            {
                this.playerScore = value;
                this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.PlayerScore));
            }
        }

        public string RemainingTime
        {
            get
            {
                return $"Time left: 00:00:{this.remainingTime} seconds";
            }
        }

        public string RemainingFlags
        {
            get
            {
                return $"Flags left: {this.Flags.Where(x => !x.IsUsed).Count().ToString()}";
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
                this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.RemainingTime));
            }
        }

        // Methods
        public void LoadNextQuestion()
        {
            this.ActualFlag = this.Flags.Where(x => !x.IsUsed).FirstOrDefault();
            if (this.ActualFlag == null)
            {
                this.RemainingTimeInSeconds = 0;
                return;
            }
            this.ActualFlag.IsUsed = true;

            this.PossibleFlags = this.Flags
                .Where(x => x.Id != this.ActualFlag.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(FakeFlagsPerRound)
                .ToList();
            this.PossibleFlags.Add(ActualFlag);
            this.PossibleFlags.Shuffle();

            this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.PossibleFlags));
            this.NotifyPropertyChanged(PropertiesHelper.GetPropertyName(() => this.RemainingFlags));
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
            this.Score += ScorePointsPerAnswer;
        }

        public void DecreaseScore()
        {
            this.Score -= ScorePointsPerAnswer;
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
