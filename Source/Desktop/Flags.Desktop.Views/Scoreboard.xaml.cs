namespace Flags.Desktop.Views
{
    using Infrastructure.Helpers;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using ViewModels.Contracts;

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
            this.Engine.Gameplay.Score = 0;
            this.Engine.Gameplay.RemainingTimeInSeconds = 60;
        }
    }
}
