using Lab2.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Lab2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentation(Position = TabbedPosition.Tab)]
    public partial class SendEmailPage : MvxContentPage<SendEmailPageViewModel>
    {
        public SendEmailPage()
        {
            InitializeComponent();
        }
    }
}