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
        Task<bool> LoginAsync(string username, SecureString password);
    }
    
}
