namespace Flags.Desktop.Views
{
    using System.Windows;

    using Infrastructure.Helpers;
    using Ninject;
    using ViewModels.Contracts;
    using Common.Constants;

    /// <summary>
    /// Interaction logic for Scoreboard.xaml
    /// </summary>
    public partial class Scoreboard : Window
    {
        public Scoreboard()
        {
            this.InitializeComponent();
            this.InitializeData();
        }

        public IEngine Engine { get; set; }

        private void InitializeData()
        {
            this.Engine = NinjectHelper.Kernel.Get<IEngine>();
            this.DataContext = this.Engine;
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            this.RestartEngine();
            var start = new StartScreen();
            start.Show();

            this.Close();
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RestartEngine()
        {
            this.Engine.Gameplay.LoadFlags();
            this.Engine.Gameplay.Score = Constants.InitialScore;
            this.Engine.Gameplay.RemainingTimeInSeconds = Constants.InitialGameTimeInSeconds;
        }
    }
}
