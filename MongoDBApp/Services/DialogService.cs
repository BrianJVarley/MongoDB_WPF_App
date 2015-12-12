using MongoDBApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MongoDBApp.Services
{
    class DialogService : IDialogService
    {

        Window loginView = null;

        public DialogService()
        {

        }

        public void CloseDialog()
        {
            if (loginView != null)
                loginView.Close();
        }

        public void ShowDialog()
        {
            loginView = new LoginView();
            loginView.ShowDialog();
        }
    }
}
