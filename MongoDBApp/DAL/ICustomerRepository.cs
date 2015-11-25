using MongoDB.Bson;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.DAL
{
    public interface ICustomerRepository
    {
        Task DeleteCustomer(CustomerModel customer);
        CustomerModel GetACustomer();
        CustomerModel GetCustomerByEmail(string email);
        CustomerModel GetCustomerById(ObjectId id);
        List<CustomerModel> GetCustomers();
        Task UpdateCustomer(CustomerModel customer);
        Task AddCustomer(CustomerModel customer);

    }
}
