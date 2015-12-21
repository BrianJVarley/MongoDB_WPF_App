using MongoDBApp.Models;
using MongoDBApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    class MockProductDataService : IDataService<ProductModel>
    {

        private MockProductRespository repository = new MockProductRespository();



        public async Task<List<ProductModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public Task<ProductModel> GetByIdAsync(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }
    }
}
