using Auth0.Windows;
using MongoDBApp.Common;
using MongoDBApp.Messages;
using MongoDBApp.Services;
using MongoDBApp.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows;

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    class LoginViewModel : IPageViewModel
    {

        public string Name { get; set; }
        public bool IsEnabled { get; set; }


        public ICommand LoginCommand { get; set; }
        private IDialogService _dialogService;
        private IAuthenticationService _authService;



        public LoginViewModel(IDialogService dialogService, IAuthenticationService authService)
        {
            this._dialogService = dialogService;
            this._authService = authService;
            LoadCommands();
        }


        public string UserName { get; set; }
        public SecureString Password { get; set; }


        private void LoadCommands()
        {
            LoginCommand = new RelayCommand(OnLogin);
        }

            
        private async void OnLogin(object obj)
        {

            var result = await _authService.LoginAsync(UserName, Password);

            if (result)
            {
                System.Windows.MessageBox.Show("You are logged in");
                Messenger.Default.Send<UpdateLoginMessage>(new UpdateLoginMessage());
            }
            else
            {
                System.Windows.MessageBox.Show("Unknown username or password.");
            }
        }


    }
}
