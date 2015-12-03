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

        
        public List<CustomerModel> GetAll()
        {
            return repository.GetAll();
        }

        public CustomerModel GetById(ObjectId id)
        {
            return repository.GetById(id);
        }

        public CustomerModel GetByEmail(string email)
        {
            return repository.GetByEmail(email);
        }


        async Task IDataService<CustomerModel>.Update(CustomerModel t)
        {
            await repository.Update(t);
        }

        async Task IDataService<CustomerModel>.Add(CustomerModel t)
        {
            await repository.Add(t);
        }

        async Task IDataService<CustomerModel>.Delete(CustomerModel t)
        {
            await repository.Delete(t);
        }
    }
}
