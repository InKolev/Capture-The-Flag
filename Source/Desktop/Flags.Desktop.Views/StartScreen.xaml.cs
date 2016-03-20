namespace Flags.Desktop.Views
{
    using System.Windows;

    using Common.Constants;
    using Infrastructure.Helpers;
    using Ninject;
    using ViewModels.Contracts;

    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        public StartScreen()
        {
            this.InitializeComponent();
            this.DataContext = NinjectHelper.Kernel.Get<IEngine>();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            if (this.textBoxPlayerName.Text.Length < Constants.PlayerNameMinLength)
            {
                MessageBox.Show("Player name must be more than 3 characters long", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var db = this.DataContext;
            var game = new Game();
            game.Show();

            this.Close();
        }
    }
}
