using Acr.UserDialogs;
using Lab2.Core.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;

namespace Lab2.Core.ViewModels
{
    public class LoginPageViewModel : MvxNavigationViewModel
    {
        private readonly IEmailService _emailService;
        private readonly IUserDialogs _userDialogs;
        public LoginPageViewModel(IMvxLogProvider provider, IMvxNavigationService navigationService,
            IEmailService emailService, IUserDialogs userDialogs)
           : base(provider, navigationService)
        {
            _emailService = emailService;
            _userDialogs = userDialogs;
        }

        #region Properties
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        #endregion

        #region Commands
        private IMvxCommand _loginCommand;
        public IMvxCommand LoginCommand => _loginCommand ?? (_loginCommand = new MvxCommand(Login));
        #endregion

        #region Private Methods
        private void Login()
        {
            try
            {
                _emailService.Initialize(Username, Password);
                NavigationService.Navigate<HomeTabPageViewModel>();
            }
            catch(Exception e)
            {
                _userDialogs.Alert(e.ToString(), "Error");
            }
        }
        #endregion
    }
}
