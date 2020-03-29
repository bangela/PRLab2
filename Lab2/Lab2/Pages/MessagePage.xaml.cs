using Lab2.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Lab2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : MvxContentPage<MessagePageViewModel>
    {
        public MessagePage()
        {
            InitializeComponent();
        }
    }
}