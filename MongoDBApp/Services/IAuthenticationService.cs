using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
   
    public interface IAuthenticationService
    {
        bool Login(string username, SecureString password);
    }
    
}
