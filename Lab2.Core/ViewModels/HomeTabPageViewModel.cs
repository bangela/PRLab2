using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.Core.ViewModels
{
    public class HomeTabPageViewModel : MvxNavigationViewModel
    {
        public HomeTabPageViewModel(IMvxLogProvider provider, IMvxNavigationService navigationService)
           : base(provider, navigationService)
        {
        }
        public override Task Initialize()
        {
            var tasks = new List<Task>
            {
                NavigationService.Navigate<InboxPageViewModel>(),
                NavigationService.Navigate<SendEmailPageViewModel>(),
            };
            return Task.WhenAll(tasks);
        }
    }
}
