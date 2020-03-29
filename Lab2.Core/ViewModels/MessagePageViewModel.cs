using Lab2.Core.Interfaces;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Lab2.Core.ViewModels
{
    public class MessagePageViewModel : MvxNavigationViewModel<int>
    {
        private readonly IEmailService _emailService;
        public MessagePageViewModel(IMvxLogProvider provider, IMvxNavigationService navigationService, IEmailService emailService)
          : base(provider, navigationService)
        {
            _emailService = emailService;
        }

        #region Properties
        private MessageViewModel _message;
        public MessageViewModel Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        #endregion
        #region Override
        public override void Prepare(int parameter)
        {
            Message = _emailService.GetEmail(parameter);
        }
        #endregion
    }
}
