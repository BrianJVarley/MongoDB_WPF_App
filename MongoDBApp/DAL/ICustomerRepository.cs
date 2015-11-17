using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public interface ICustomerRepository
    {
        void DeleteCustomer(CustomerModel customer);
        CustomerModel GetCustomerByEmail(string email);
        List<CustomerModel> LoadCustomers();
        void UpdateCustomer(CustomerModel customer);
        List<CustomerModel> GetCustomers();


    }
}
