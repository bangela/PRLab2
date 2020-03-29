using Lab2.Core.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Lab2.Core.ViewModels
{
    public class InboxPageViewModel : MvxNavigationViewModel
    {
        private readonly IEmailService _emailService;
        public InboxPageViewModel(IMvxLogProvider provider, IMvxNavigationService navigationService, IEmailService emailService)
          : base(provider, navigationService)
        {
            _emailService = emailService;
            Messages = new MvxObservableCollection<MessageHeaderViewModel>();
        }
        #region Overridies
        public override  void Prepare()        
        {
            var messagesList = _emailService.GetInbox();
            Messages.AddRange(messagesList);
        }
        #endregion
        #region Properties
        private MvxObservableCollection<MessageHeaderViewModel> _messages;
        public MvxObservableCollection<MessageHeaderViewModel> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }
        #endregion

        #region Commands
        private IMvxCommand<MessageHeaderViewModel> _goToMessageCommand;
        public IMvxCommand<MessageHeaderViewModel> GoToMessageCommand => _goToMessageCommand ??
            (_goToMessageCommand = new MvxCommand<MessageHeaderViewModel>(GoToMessage));
        #endregion

        #region Private Methods
        public void GoToMessage(MessageHeaderViewModel message)
        {
            NavigationService.Navigate<MessagePageViewModel, int>(message.Id);
        }
        #endregion
    }
}
