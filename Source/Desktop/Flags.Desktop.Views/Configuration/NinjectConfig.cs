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
            Bind<IFlagsDbContext>().To<FlagsDbContext>();
            Bind<IGameplay>().To<GameplayViewModel>();
            Bind<IEngine>().To<EngineViewModel>();
        }
    }
}
