using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    class OrderDataService : IDataService<OrderModel>
    {

        IRepository<OrderModel> repository;

        public OrderDataService(IRepository<OrderModel> repository)
        {
            this.repository = repository;

        }


        public async Task<List<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> GetByIdAsync(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

     
        public async Task UpdateAsync(OrderModel t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(OrderModel t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(OrderModel t)
        {
            throw new NotImplementedException();
        }


        public async Task<List<OrderModel>> GetAllByEmailAsync(string email)
        {          
            return await repository.GetAllByEmailAsync(email);
        }
    }
}
