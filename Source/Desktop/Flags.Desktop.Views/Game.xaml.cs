namespace Flags.Desktop.Views
{
    using Flags.Data;
    using Ninject;
    using System;
    using System.Collections.Generic;
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
        public Game(string playerName)
        {
            this.InitializeComponent();
            this.InitializeKernel();
            this.InitializeData(playerName);
            this.InitializeTimer();
        }

        private IEngine Engine { get; set; }

        private DispatcherTimer Timer { get; set; }

        private void AnswerQuestion(object sender, RoutedEventArgs e)
        {
            if(this.Engine.Gameplay.ActualFlag == null)
            {
                return;
            }

            var senderAsButton = sender as Button;
            var senderName = senderAsButton.Content.ToString();

            if (this.Engine.Gameplay.ActualFlag.Name == senderName)
            {
                this.Engine.Gameplay.IncreaseScore();
                this.Engine.Gameplay.LoadNextQuestion();
            }
            else
            {
                this.Engine.Gameplay.DecreaseScore();
                this.Engine.Gameplay.LoadNextQuestion();
            }
        }

        private void NextQuestion(object sender, RoutedEventArgs e)
        {
            this.Engine.Gameplay.LoadNextQuestion();
        }

        private void InitializeKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            this.Engine = kernel.Get<IEngine>();
        }

        private void InitializeTimer()
        {
            this.Timer = new DispatcherTimer();
            this.Timer.Tick += OnTimerTick;
            this.Timer.Interval = new TimeSpan(0, 0, 1);
            this.Timer.Start();
        }

        private void InitializeData(string playerName)
        {
            this.Engine.Gameplay.PlayerName = playerName;
            this.DataContext = this.Engine;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.Engine.Gameplay.RemainingTimeInSeconds > 0)
            {
                this.Engine.Gameplay.UpdateTime();
            }
            else
            {
                this.Timer.Stop();

                var dialogResult = MessageBox.Show("Your time is over, or there are no more flags left. Would you like to save your result to The Scoreboard?", "GAME OVER", MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.OK)
                {
                    // Add to scoreboard
                }
                else
                {
                    // Don't add to scoreboard
                }


                // Display Scoreboard, Button for Restart game, or exit game
            }
        }
    }
}
