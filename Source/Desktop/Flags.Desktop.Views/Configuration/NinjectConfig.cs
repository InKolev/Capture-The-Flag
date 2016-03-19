namespace Flags.Desktop.Views.Configuration
{
    using Data;
    using Ninject.Modules;
    using ViewModels;
    using ViewModels.Contracts;

    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IFlagsDbContext>().To<FlagsDbContext>().InSingletonScope();
            Bind<IGameplay>().To<GameplayViewModel>();
            Bind<IStartScreen>().To<StartScreenViewModel>();
            Bind<IScoreboard>().To<ScoreboardViewModel>();
            Bind<IEngine>().To<EngineViewModel>().InSingletonScope();
        }
    }
}
