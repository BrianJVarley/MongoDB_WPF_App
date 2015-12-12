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
        public bool IsLoggedIn { get; set; }


        public ICommand LoginCommand { get; set; }
        private IDialogService _dialogService; 


        private Auth0Client auth0 = new Auth0Client(ConfigurationManager.AppSettings["auth0:Domain"],
                                                    ConfigurationManager.AppSettings["auth0:ClientId"]);

        public LoginViewModel(IDialogService dialogService)
        {
            this._dialogService = dialogService;
            LoadCommands();
        }


        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionName = ConfigurationManager.AppSettings["auth0: ConnectionName"];


        private void LoadCommands()
        {
            LoginCommand = new RelayCommand(LoginCustomer);
        }

        


        #region OAuth screen invoke


        private void LoginCustomer(object obj)
        {

            auth0.LoginAsync(connection: ConnectionName, userName: User, password: Password).ContinueWith(t =>
            {
                if (t.IsFaulted){

                    IsLoggedIn = false;
                    System.Windows.MessageBox.Show("Login failed!", "Not Logged In", MessageBoxButton.OK, MessageBoxImage.Warning);
      
                }
                   
                else
                    IsLoggedIn = true;
                Messenger.Default.Send<UpdateLoginMessage>(new UpdateLoginMessage());

            },
           TaskScheduler.FromCurrentSynchronizationContext());

        }




        #endregion

    }
}
