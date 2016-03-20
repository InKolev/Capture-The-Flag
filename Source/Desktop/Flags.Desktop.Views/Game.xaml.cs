namespace Flags.Desktop.Views
{
    using System;
    using System.Windows;
    using System.Windows.Threading;

    using Common.Constants;
    using Infrastructure.Helpers;
    using Ninject;
    using ViewModels.Contracts;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            this.InitializeComponent();
            this.InitializeData();
            this.InitializeTimer();
        }

        private IEngine Engine { get; set; }

        private DispatcherTimer Timer { get; set; }
     
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
            this.Engine = NinjectHelper.Kernel.Get<IEngine>();
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
                    this.Engine.Gameplay.AddScoreToScoreboard();
                    this.Engine.Scoreboard.UpdateScores();
                }

                var scoreboard = new Scoreboard();
                scoreboard.Show();

                this.Close();
            }
        }
    }
}
