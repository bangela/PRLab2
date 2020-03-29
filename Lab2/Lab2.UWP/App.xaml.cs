using Acr.UserDialogs;
using MvvmCross.Forms.Platforms.Uap.Views;
using Windows.ApplicationModel.Activation;

namespace Lab2.UWP
{
    public abstract class UwpApp : MvxWindowsApplication<Setup, Core.App, Lab2.App, MainPage>
    {
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

            global::Xamarin.Forms.Forms.Init(e);
            UserDialogs.Init();
            base.OnLaunched(e);
        }
    }
   
}
