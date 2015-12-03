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
    class MockCustomerDataService : IDataService<CustomerModel>
    {

        private MockRepository repository = new MockRepository();

        public void DeleteCustomer(CustomerModel customer)
        {
            repository.DeleteCustomer(customer);
        }
   
      
        public List<CustomerModel> GetAll()
        {
            return repository.GetCustomers();
        }

        public CustomerModel GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByEmail(string email)
        {
            CustomerModel customer = repository.GetCustomerByEmail(email);
            return customer;
        }

        public Task Update(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public Task Add(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CustomerModel t)
        {
            throw new NotImplementedException();
        }
    }
}
