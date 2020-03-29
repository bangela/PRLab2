using Lab2.Core;
using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.IoC;

namespace Lab2.UWP
{
    public class Setup : MvxFormsWindowsSetup<Lab2.Core.App, Lab2.App>
    {
        protected override IMvxIoCProvider InitializeIoC()
        {
            var provider = base.InitializeIoC();
            return SetupIoC.RegisterDependencies(provider);
        }
    }
}
