namespace Flags.Desktop.ViewModels.Contracts
{
    public interface IEngine
    {
        IStartScreen StartScreen { get; set; }

        IGameplay Gameplay { get; set; }

        IScoreboard Scoreboard { get; set; }
    }
}