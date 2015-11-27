using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBApp.DAL;
using MongoDBApp.Models;
using MongoDBApp.Services;
using MongoDB.Bson;

namespace Tests.Mocks
{
    class MockCustomerDataService : ICustomerDataService
    {

        private MockRepository repository = new MockRepository();

        public void DeleteCustomer(CustomerModel customer)
        {
            repository.DeleteCustomer(customer);
        }

        public CustomerModel GetACustomer()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            CustomerModel customer = repository.GetCustomerByEmail(email);
            return customer;
        }

        public CustomerModel GetCustomerById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            return repository.GetCustomers();
        }

 
        public Task DeleteCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

    
        public List<CustomerModel> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerDetail(ObjectId id)
        {
            throw new NotImplementedException();
        }

        void UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        void AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
