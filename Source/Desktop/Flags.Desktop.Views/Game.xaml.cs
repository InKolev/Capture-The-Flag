namespace Flags.Desktop.Views
{
    using Common.Constants;
    using Configuration;
    using Data.Models;
    using Flags.Data;
    using Infrastructure.Helpers;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using ViewModels;
    using ViewModels.Contracts;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            this.InitializeComponent();
            this.InitializeEngine();
            this.InitializeData();
            this.InitializeTimer();
        }

        private IEngine Engine { get; set; }

        private DispatcherTimer Timer { get; set; }

        private void InitializeEngine()
        {
            this.Engine = NinjectHelper.Kernel.Get<IEngine>();
        }

        private void InitializeTimer()
        {
            this.Timer = new DispatcherTimer();
            this.Timer.Tick += OnTimerTick;
            this.Timer.Interval = new TimeSpan(
                Constants.TimerTickIntervalInHours, 
                Constants.TimerTickIntervalInMinutes, 
                Constants.TimerTickIntervalInSeconds);
            this.Timer.Start();
        }

        private void InitializeData()
        {
            this.Engine.Gameplay.PlayerName = this.Engine.StartScreen.PlayerName;
            this.DataContext = this.Engine;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.Engine.Gameplay.RemainingTimeInSeconds > Constants.NoTimeLeftInSeconds)
            {
                this.Engine.Gameplay.UpdateTime();
            }
            else
            {
                this.Timer.Stop();

                var dialogResult = MessageBox.Show(
                    "Your time is over, or there are no more flags left. Would you like to Save your result to The Scoreboard?", 
                    "GAME OVER", 
                    MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    this.AddScoreToScoreboard();
                }

                var scoreboard = new Scoreboard();
                scoreboard.Show();

                this.Close();
            }
        }

        private void AddScoreToScoreboard()
        {
            var score = this.Engine.Gameplay.DbContext.Scores.SingleOrDefault(x => x.PlayerName == this.Engine.Gameplay.PlayerName);

            if (score == null)
            {
                score = new Score()
                {
                    PlayerName = this.Engine.Gameplay.PlayerName,
                    Value = this.Engine.Gameplay.Score
                };
            }
            else
            {
                score.Value = this.Engine.Gameplay.Score;
            }

            this.Engine.Gameplay.DbContext.Scores.AddOrUpdate(score);
            this.Engine.Gameplay.DbContext.Save();
            this.Engine.Scoreboard.UpdateScores();
        }
    }
}
