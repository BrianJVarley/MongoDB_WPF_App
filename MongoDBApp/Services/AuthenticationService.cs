using Auth0.Windows;
using MongoDBApp.Messages;
using MongoDBApp.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {


        private Auth0Client auth0 = new Auth0Client(ConfigurationManager.AppSettings["auth0:Domain"],
                                                    ConfigurationManager.AppSettings["auth0:ClientId"]);


        public bool Login(string username, SecureString password)
        {
            IntPtr passwordBSTR = default(IntPtr);
            string insecurePassword = "";
            try
            {
                passwordBSTR = Marshal.SecureStringToBSTR(password);
                insecurePassword = Marshal.PtrToStringBSTR(passwordBSTR);
            }
            catch
            {
                insecurePassword = "";
            }
            return LoginService(username, insecurePassword);
        }

        
        private bool LoginService(string username, string password)
        {

            string ConnectionName = "Username-Password-Authentication";

            auth0.LoginAsync(connection: ConnectionName, userName: username, password: password).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    return false;
                }
                else
                {
                    Messenger.Default.Send<UpdateLoginMessage>(new UpdateLoginMessage());
                    return true;                  
                }

            },
           
           TaskScheduler.FromCurrentSynchronizationContext());
        }



    }
}
