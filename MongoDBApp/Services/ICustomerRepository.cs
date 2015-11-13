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
        void DeleteCustomer(Customer customer);
        Customer GetCustomerByEmail(string email);
        List<Customer> LoadCustomers();
        void UpdateCustomer(Customer customer);

    }
}
