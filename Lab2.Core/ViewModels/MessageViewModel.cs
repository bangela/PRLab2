using MvvmCross.ViewModels;

namespace Lab2.Core.ViewModels
{
    public class MessageViewModel : MvxNotifyPropertyChanged
    {
        private string _from;
        private string _title;
        private string _body;

        public string From
        {
            get => _from;
            set => SetProperty(ref _from, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Body
        {
            get => _body;
            set => SetProperty(ref _body, value);
        }
    }
}
