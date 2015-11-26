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
    class MockCustomerDataService : ICustomerRepository
    {
        public void DeleteCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetACustomer()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
        }




        public Task UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        Task ICustomerRepository.DeleteCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
