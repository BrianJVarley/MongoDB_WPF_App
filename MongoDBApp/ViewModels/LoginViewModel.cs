using Auth0.Windows;
using MongoDBApp.Common;
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

        public ICommand LoginCommand { get; set; }

        private Auth0Client auth0 = new Auth0Client(ConfigurationManager.AppSettings["auth0:Domain"],
                                                    ConfigurationManager.AppSettings["auth0:ClientId"]);

        public LoginViewModel()
        {

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

                    IsEnabled = false;
                    System.Windows.MessageBox.Show("Login failed!: ", "Not Logged In", MessageBoxButton.OK, MessageBoxImage.Warning);
      
                }
                   
                else
                    IsEnabled = true;
            },
           TaskScheduler.FromCurrentSynchronizationContext());

        }




        #endregion

    }
}
