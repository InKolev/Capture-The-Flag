namespace Flags.Desktop.Views
{
    using Configuration;
    using Infrastructure.Helpers;
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
    using System.Windows.Shapes;
    using ViewModels;
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
            if(this.textBoxPlayerName.Text.Length < 2)
            {
                MessageBox.Show("Player name must be more than 2 characters long", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var db = this.DataContext;
            var game = new Game();
            game.Show();

            this.Close();
        }
    }
}
