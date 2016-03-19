namespace Flags.Desktop.ViewModels
{
    using Contracts;

    public class EngineViewModel : IEngine
    {
        public EngineViewModel(IStartScreen startScreen,IGameplay gameplay, IScoreboard scoreboard)
        {
            this.StartScreen = startScreen;
            this.Gameplay = gameplay;
            this.Scoreboard = scoreboard;
        }

        public IStartScreen StartScreen { get; set; }

        public IGameplay Gameplay { get; set; }

        public IScoreboard Scoreboard { get; set; }
    }
}
