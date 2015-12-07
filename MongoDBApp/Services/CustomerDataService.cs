using MongoDB.Bson;
using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public class CustomerDataService : IDataService<CustomerModel>
    {

        IRepository<CustomerModel> repository;

        public CustomerDataService(IRepository<CustomerModel> repository)
        {
            this.repository = repository;  
        }




        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<CustomerModel> GetByIdAsync(ObjectId id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<CustomerModel> GetByEmailAsync(string email)
        {
            return await repository.GetByEmailAsync(email);
        }

        public async Task UpdateAsync(CustomerModel t)
        {
            await repository.UpdateAsync(t);
        }

        public async Task AddAsync(CustomerModel t)
        {
            await repository.AddAsync(t);
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
