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

        private MockCustomerRepository repository = new MockCustomerRepository();



        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public Task<CustomerModel> GetByIdAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerModel> GetByEmailAsync(string email)
        {
            return await repository.GetByEmailAsync(email);
        }

        public async Task UpdateAsync(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(CustomerModel t)
        {
           await repository.DeleteAsync(t); 
        }


        public Task<List<CustomerModel>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
