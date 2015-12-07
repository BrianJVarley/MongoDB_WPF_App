using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    class CountryDataService : IDataService<Country>
    {

        IRepository<Country> repository;

        public CountryDataService(IRepository<Country> repository)
        {
            this.repository = repository;  
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Country> GetByIdAsync(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<Country> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Country t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Country t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Country t)
        {
            throw new NotImplementedException();
        }


        public Task<List<Country>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
