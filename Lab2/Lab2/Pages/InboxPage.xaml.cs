using Lab2.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Lab2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentation(Position = TabbedPosition.Tab)]
    public partial class InboxPage : MvxContentPage<InboxPageViewModel>
    {
        public InboxPage()
        {
            InitializeComponent();
            List.ItemTapped += List_ItemTapped;
        }

        private void List_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ViewModel.GoToMessageCommand.Execute(e.Item as MessageHeaderViewModel);
        }
    }
}