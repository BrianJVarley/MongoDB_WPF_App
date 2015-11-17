using MongoDB.Bson;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    interface ICustomerDataService
    {
        void DeleteCustomer(CustomerModel customer);
        CustomerModel GetCustomerByEmail(string email);
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerDetail(ObjectId id);
        void UpdateCustomer(CustomerModel customer);
        
    }
}
