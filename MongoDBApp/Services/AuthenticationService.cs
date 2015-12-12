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








        private async Task<bool> LoginServiceAsync(string username, string password)
        {
            string ConnectionName = "Username-Password-Authentication";

            try
            {
                var result = await auth0.LoginAsync(
                    connection: ConnectionName, userName: username, password: password);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }




        public async Task<bool> LoginAsync(string username, SecureString password)
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
            var loginResult = await LoginServiceAsync(username, insecurePassword);
            return loginResult;
              
        }
    }
}
