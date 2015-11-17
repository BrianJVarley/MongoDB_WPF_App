using MongoDB.Bson;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    class CustomerDataService : ICustomerDataService
    {

        ICustomerRepository repository;

        public CustomerDataService(ICustomerRepository repository)
        {
            this.repository = repository;  
        }

        
        public CustomerModel GetCustomerDetail(ObjectId id)
        {
            return repository.GetCustomerById(id);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return repository.GetCustomers();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            repository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(CustomerModel customer)
        {
            repository.DeleteCustomer(customer);
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            return repository.GetCustomerByEmail(email);
        }


       
    }
}
