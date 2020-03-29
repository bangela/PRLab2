using MvvmCross.ViewModels;
using System;

namespace Lab2.Core.ViewModels
{
    public class MessageHeaderViewModel : MvxNotifyPropertyChanged
    {
        private string _from;
        private string _title;
        private string _date;
        private int _id;

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

        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
    }
}
