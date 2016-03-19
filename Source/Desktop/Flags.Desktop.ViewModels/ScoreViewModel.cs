namespace Flags.Desktop.ViewModels
{
    using System;

    public class ScoreViewModel
    {
        public string PlayerName { get; set; }

        public int Value { get; set; }

        public DateTime DateCreated { get; set; }

        public string ScoreboardRow
        {
            get
            {
                return $"Player: {this.PlayerName} - Date: {this.DateCreated.ToShortDateString()} - Score: {this.Value}";
            }
        }
    }
}
