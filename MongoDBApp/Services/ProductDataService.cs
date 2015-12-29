using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public class ProductDataService : IDataService<ProductModel>
    {


        IRepository<ProductModel> repository;


        public ProductDataService(IRepository<ProductModel> repository)
        {
            this.repository = repository;

        }

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

        public async Task UpdateAsync(ProductModel t)
        {
            await repository.UpdateAsync(t)
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
