using MongoDBApp.Services;
using MongoDBApp.Utility;
using MongoDBApp.ViewModels;
using MongoDBApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MongoDBApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static IDialogService dialogService = new DialogService();
        private static IAuthenticationService authoService = new AuthenticationService();
        private LoginView login;
        private ApplicationView app;
   

        public App()
        {
            Messenger.Default.Register<string>(this, OnLoggedInMessageReceived);

        }


        private void OnLoggedInMessageReceived(string username)
        {           
            app = new ApplicationView();
            var appVM = new ApplicationViewModel();
            app.DataContext = appVM;
            app.Show();
            login.Hide();
            
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            login = new LoginView();
            var loginVM = new LoginViewModel(dialogService,authoService);
            login.DataContext = loginVM;
            login.Show();
                             
        }

    }
}
