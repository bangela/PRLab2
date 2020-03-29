using Acr.UserDialogs;
using Lab2.Core.Interfaces;
using Lab2.Core.Services;
using MvvmCross.IoC;

namespace Lab2.Core
{
    public static class SetupIoC
    {
        public static IMvxIoCProvider RegisterDependencies(IMvxIoCProvider provider)
        {
            provider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            provider.ConstructAndRegisterSingleton<IEmailService, EmailService>();
            return provider;
        }
    }
}
