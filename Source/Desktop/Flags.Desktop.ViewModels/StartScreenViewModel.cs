namespace Flags.Desktop.ViewModels
{
    using Contracts;
    using Infrastructure.Helpers;
    using System.ComponentModel;

    public class StartScreenViewModel : IStartScreen
    {
        public string GameStartButton { get; set; } = "Start game";

        public string GameTitle { get; set; } = "Capture the flag";

        public string PlayerName { get; set; }

        public string PlayerNameLabel { get; set; } = "Enter your name: ";
    }
}