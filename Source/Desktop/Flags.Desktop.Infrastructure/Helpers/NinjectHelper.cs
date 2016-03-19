namespace Flags.Desktop.Infrastructure.Helpers
{
    using System.Reflection;
    using Ninject;
    using System;

    public static class NinjectHelper
    {
        static NinjectHelper()
        {
            Kernel = new StandardKernel();
            Kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static StandardKernel Kernel { get; set; }
    }
}
