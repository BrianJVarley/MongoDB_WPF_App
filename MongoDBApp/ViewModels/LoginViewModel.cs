using Auth0.Windows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    class LoginViewModel : IPageViewModel
    {

        public string Name {get;}
        public bool IsEnabled { get; set; }

        private Auth0Client auth0 = new Auth0Client(ConfigurationManager.AppSettings["auth0:Domain"],
                                                    ConfigurationManager.AppSettings["auth0:ClientId"]);

        public LoginViewModel()
        {


        }
       
    }
}
