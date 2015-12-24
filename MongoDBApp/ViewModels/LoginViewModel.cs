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


namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    class LoginViewModel : IPageViewModel
    {

        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }


        public ICommand LoginCommand { get; set; }
        private IAuthenticationService _authService;



        public LoginViewModel(IAuthenticationService authService)
        {
            this._authService = authService;
            LoadCommands();

            UserName = UserSettings.Default.UserName;

        }


        public string UserName  { get; set; }
        public SecureString Password { get; set; }


        private void LoadCommands()
        {
            LoginCommand = new RelayCommand(OnLogin);
        }

            
        private async void OnLogin(object obj)
        {
            IsActive = true;

            var result = await _authService.LoginAsync(UserName, Password);


            if (result)
            {
                // Update the value.
                UserSettings.Default.UserName = UserName;
                // Save the config file.
                UserSettings.Default.Save();

                Messenger.Default.Send<string>(UserName);
                IsActive = false;               
            }
            else
            {
                System.Windows.MessageBox.Show("Invalid username or password.");
                IsActive = false;
            }
            return;
        }


    }
}
