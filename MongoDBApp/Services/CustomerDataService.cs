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

        public void DeleteCustomer(CustomerModel customer)
        {
            repository.DeleteCustomer(customer);
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            return repository.GetCustomerByEmail(email);
        }

        public List<CustomerModel> LoadCustomers()
        {
            return repository.LoadCustomers();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            repository.UpdateCustomer(customer);
        }

        public List<CustomerModel> GetCustomers()
        {
            return repository.LoadCustomers();
        }
    }
}
