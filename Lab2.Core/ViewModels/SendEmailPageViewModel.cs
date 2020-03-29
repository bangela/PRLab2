using Acr.UserDialogs;
using Lab2.Core.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Lab2.Core.ViewModels
{
    public class SendEmailPageViewModel : MvxNavigationViewModel
    {
        private IEmailService _emailService;
        private IUserDialogs _userDialogs;
        public SendEmailPageViewModel(IMvxLogProvider provider, IMvxNavigationService navigationService, IEmailService emailService,
            IUserDialogs userDialogs)
         : base(provider, navigationService)
        {
            _emailService = emailService;
            _userDialogs = userDialogs;
        }
        #region Properties
        private string _to;
        public string To
        {
            get => _to;
            set => SetProperty(ref _to, value);
        }

        private string _subject;
        public string Subject
        {
            get => _subject;
            set => SetProperty(ref _subject, value);
        }

        private string _body;
        public string Body
        {
            get => _body;
            set => SetProperty(ref _body, value);
        }
        #endregion

        #region Commands
        private IMvxCommand _sendEmailCommand;
        public IMvxCommand SendEmailCommand => _sendEmailCommand ?? (_sendEmailCommand = new MvxCommand(SendEmail));
        #endregion
        #region Private Methods
        private void SendEmail()
        {
            _emailService.SendEmail(To, Subject, Body);
            _userDialogs.Alert("Message succesful sent", "Message");
        }
        #endregion
    }
}
