namespace Flags.Desktop.ViewModels
{
    using Contracts;
    using Data;
    using Ninject;

    public class EngineViewModel : IEngine
    {
        public EngineViewModel(IGameplay gameplay)
        {
            this.Gameplay = gameplay;
        }

        public IGameplay Gameplay { get; set; }
    }
}